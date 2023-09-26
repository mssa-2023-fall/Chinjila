// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using Dapper;
using System.Xml;
using CustomerSQL;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Configuration;

internal class Program
{
    static string ConnStr=string.Empty;

    private static void Main(string[] args)
    {
        var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
        ConnStr = config["connstring"];
        Console.WriteLine("Customer Table Exercise");
        do
        {
            PrintMenu();

            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    CreateTable();
                    break;
                case ConsoleKey.NumPad2: 
                case ConsoleKey.D2:
                    Populate100Customers();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    DisplayCustomers();
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    DeleteCustomer();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    DisplayCustomerCount();
                    break;
                default:
                    break;
            }


            if (key == ConsoleKey.Q) break;

        } while (true);

        void DisplayCustomerCount()
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                var sql = "SELECT COUNT(*) FROM vc.Customers";
                var task = connection.ExecuteScalarAsync(sql);
                Console.WriteLine("Please wait...");
                Console.WriteLine($"There are {task.Result} customers.");
            }
        }

        void DeleteCustomer()
        {
            Console.WriteLine("Enter customer id:");
            var custID =Console.ReadLine();
            Console.WriteLine($"Reading customer id {custID}");
            using (var connection = new SqlConnection(ConnStr))
            {
                var sql = "SELECT * FROM vc.Customers where CustomerID=@custID";
                Customer toBeDeleted;
                try { toBeDeleted = connection.QuerySingle<Customer>(sql, new { custID = custID }); }
                catch (InvalidOperationException)  { Console.WriteLine($"Cant find customer id:{custID}");return; }
                
                Console.WriteLine($"Do you want to delete id:{toBeDeleted.CustomerID}-{toBeDeleted.CustomerName}-{toBeDeleted.DateOfBirth:MM-dd-yyyy}");
                Console.WriteLine($"Y/[N]");
                if (Console.ReadLine()?.ToUpper() == "Y")
                {
                    var deleteSql = "delete FROM vc.Customers where CustomerID=@custID";
                    int i = connection.Execute(deleteSql, new { custID = custID });
                    Console.WriteLine($"{i} row deleted");
                }

            }
        }

        void DisplayCustomers()
        {
            using (var connection = new SqlConnection(ConnStr))
            {
                string sql = "Select * from vc.Customers";
                var t=connection.QueryAsync<Customer>(sql);
                int rowCounter = 0;
                int spinnerCounter = 0;
                Console.Write("Fetching customer.");
                while (!t.IsCompleted) {
                    switch (spinnerCounter % 4)
                    {
                        case 0: Console.Write("/"); break;
                        case 1: Console.Write("-"); break;
                        case 2: Console.Write("\\"); break;
                        case 3: Console.Write("|"); break;
                    }
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    spinnerCounter++;
                    Task.Delay(100).Wait();
                }
                foreach (var customer in t.Result) {
                    if (rowCounter%40 == 0)
                    {
                        Console.WriteLine(new string('-', 44));
                        Console.WriteLine($"|{"ID",5}|{"Name",15}|{"Age",5}|{"Birthday",15:MM-DD-YYYY}");
                        Console.WriteLine(new string('-', 44));
                    }
                    Console.WriteLine($"|{customer.CustomerID,5}|{customer.CustomerName,15}|{customer.Age,5}|{customer.DateOfBirth,15:MM-dd-yyyy}");
                    rowCounter++;
                } 
            }
        }

        void Populate100Customers()
        {
            List<Object> customersToAdd = new List<Object>();
            using (var connection = new SqlConnection(ConnStr))
            {

                string sql = @"
                       insert into vc.customers(customerName,DateOfBirth)
                       values(@customerName,@DateOfBirth);
                        ";
                for (int i = 0; i < 100; i++)
                {
                    var parameters = new { customerName = $"John Doe{i}", DateOfBirth = new DateTime(1980, 1, 1).AddDays(Random.Shared.Next(1,10000)) };
                    customersToAdd.Add(parameters);

                }
                var t = connection.ExecuteAsync(sql, customersToAdd);
                Console.Write("Adding customer");
                while (!t.IsCompleted)
                {
                    Task.Delay(500).Wait();
                    Console.Write(".");
                }
                ;
                Console.WriteLine("Done.");
            }
        }

        void CreateTable()
        {
            string sql =
             @"
    Drop Table if exists vc.Customers;
      
    CREATE TABLE [vc].[Customers] (
    [CustomerID]   INT           IDENTITY (1, 1) NOT NULL,
    [CustomerName] NVARCHAR (50) NOT NULL,
    [DateOfBirth]  DATETIME2 (7) NOT NULL,
    [Age]     AS            (datediff(year, [DateOfBirth], getdate())),
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
    );
    ";
            using (var connection = new SqlConnection(ConnStr))
            {
                Task t =connection.ExecuteAsync(sql);
                Console.Write("Creating Table.");
                while (!t.IsCompleted)
                {
                    Task.Delay(300).Wait();
                    Console.Write(".");
                }
            }
            
            Console.WriteLine("Customer Table Created");
        }

        void PrintMenu()
        {
            Console.WriteLine(@"
1 - Create Customer Table - CustomerID identity
2 - Generate 100 Unique Customer
3 - Display All Customers
4 - Delete a Customer
5 - Display Count Of Customers
Q - quit
");
        }
    }
}