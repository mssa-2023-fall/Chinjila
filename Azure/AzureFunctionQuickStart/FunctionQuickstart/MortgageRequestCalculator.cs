using System;
using System.Diagnostics;
using System.Text.Json;
using Azure;
using Azure.Data.Tables;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using MortgageCalculatorLibrary;

namespace FunctionQuickstart
{
    public class MortgageRequestCalculator
    {
        private readonly ILogger<MortgageRequestCalculator> _logger;

        public MortgageRequestCalculator(ILogger<MortgageRequestCalculator> logger)
        {
            _logger = logger;
        }

        [Function(nameof(MortgageRequestCalculator))]
        [TableOutput("MortgageResult", Connection = "imgstorvc")]
        public MortgagePayment Run([QueueTrigger("mortgage-request", Connection = "imgstorvc")] QueueMessage message)
        {
            MortgageRequest? request = JsonSerializer.Deserialize<MortgageRequest>(message.Body.ToString());
            if(request == null) { throw new ArgumentNullException(nameof(message)); }
            var mortgage = new Mortgage(request.InterestRate, request.Principal, DateTime.Now, request.LoanTermInYears, 0);
            var monthlyPayment = mortgage.CalculateMonthlyPayment();
            var tableEntry =  new MortgagePayment(request.Principal, request.InterestRate, request.LoanTermInYears, monthlyPayment);
            return tableEntry;
        }

    }
    public class MortgagePayment : ITableEntity
    {
        public string PartitionKey { get { return Principal.ToString(); } set { Debug.WriteLine($"setting partitionkey={value}"); }  }
        public string RowKey { get { return $"{LoanTerm}-{InterestRate}"; } set { Debug.WriteLine($"setting rowkey={value}"); } }

        DateTimeOffset? ITableEntity.Timestamp { get; set;}
        ETag ITableEntity.ETag { get; set;}
        public int LoanTerm { get => _loanTerm; set => _loanTerm = value; }
        public decimal InterestRate { get => _interestRate; set => _interestRate = value; }
        public decimal Payment { get => _payment; set => _payment = value; }
        public decimal Principal { get => _principal; set => _principal = value; }

        decimal _principal;
        int _loanTerm;
        decimal _interestRate;
        decimal _payment;
        public MortgagePayment(decimal principal, decimal interestRate, int loanTermInYear, decimal payment)
        {
            Principal = principal;
            LoanTerm = loanTermInYear;
            InterestRate = interestRate;
            Payment = payment;

        }
    }
}
