using System;
using System.Text.Json;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionQuickstart
{
    public class MortgageRequestGenerator
    {
        private readonly ILogger _logger;

        public MortgageRequestGenerator(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MortgageRequestGenerator>();
        }

        [Function("MortgageRequestGenerator")]
        [QueueOutput("mortgage-request",Connection = "imgstorvc")]
        public string Run([TimerTrigger("*/3 * * * * *")] MyInfo myTimer)
        {
            var principal = Random.Shared.Next(20, 100) * 10_000;
            decimal interestRate = Math.Round(Random.Shared.Next(100, 800) / 100m,2);
            int durationInYear = Random.Shared.Next(10, 30) ;

            var mortgageRequest = new MortgageRequest()
            {
                Principal = principal,
                InterestRate = interestRate,
                LoanTermInYears = durationInYear
            };
            return JsonSerializer.Serialize(mortgageRequest);
            
        }
    }

    public class MortgageRequest
    { 
      public decimal Principal { get; set; }
      public decimal InterestRate { get; set; }
      public int LoanTermInYears { get; set; }

    }

    public class MyInfo
    {
        public MyScheduleStatus ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MyScheduleStatus
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
