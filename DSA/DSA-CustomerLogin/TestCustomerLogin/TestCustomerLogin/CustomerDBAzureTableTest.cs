using Azure.Core;
using Azure.Data.Tables;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using CustomerLogin;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestCustomerLogin
{
    [TestClass]
    public class CustomerDBAzureTableTest
    {
        private TableClient _tableClient;
        private TableServiceClient _serviceClient;
        private string _tableName;
        private CryptographyClient _cryptographyClient;
        [TestInitialize] 
        public void Init() {
            var config = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly(), true).Build();
            
            _serviceClient = new TableServiceClient(config["Azure:TableConnStr"]);
            var keyClient = new KeyClient(new Uri(config["Azure:KeyVaultUri"]),
                new ClientSecretCredential(config["Azure:TenantID"], config["Azure:ClientID"], config["Azure:ClientSecret"]));
            _cryptographyClient = keyClient.GetCryptographyClient("mssa");
            _tableName = config["Azure:TableName"] + Guid.NewGuid().ToString().Substring(0, 5);

            _serviceClient.DeleteTableAsync(_tableName.ToLower()).Wait();
            _serviceClient.CreateTableIfNotExistsAsync(_tableName).Wait();
            _tableClient = _serviceClient.GetTableClient(_tableName);
            Customer alice = new Customer("alice", "alice@live.com", "password", "11112222", _cryptographyClient);
            Customer bob = new Customer("bob", "bob@live.com", "password", "11112222", _cryptographyClient);
            Customer charlie = new Customer("charlie", "charlie@live.com", "password", "11112222", _cryptographyClient);
            Task.WaitAll(
            _tableClient.AddEntityAsync(alice),
            _tableClient.AddEntityAsync(bob),
            _tableClient.AddEntityAsync(charlie));
        }
        [TestMethod()]
        public void CreateCustomer()
        {
            Customer david = new Customer("david", "david@live.com", "password", "11112222", _cryptographyClient);
            _tableClient.AddEntityAsync(david).Wait();
            var david2 = _tableClient.GetEntityAsync<Customer>("david@live.com", "david").Result.Value;
            Assert.AreEqual(david.Name, david2.Name);
            Assert.AreEqual(Convert.ToBase64String(david.Salt), Convert.ToBase64String(david.Salt));
            Assert.AreEqual(Convert.ToBase64String(david.PasswordHash), Convert.ToBase64String(david.PasswordHash));
            Assert.AreEqual(Convert.ToBase64String(david.CreditCardHash), Convert.ToBase64String(david.CreditCardHash));
        }
        [TestMethod]
        public void TestCustomerDBConstructorWithTableClient()
        {
            var customerDB = new CustomersDB(_tableClient);
            Assert.IsTrue(customerDB.Count>=3);
        }
        [TestMethod]
        public void VerifyCustomerData()
        {
            var customerDB = new CustomersDB(_tableClient);
            Assert.AreEqual("alice",customerDB["alice@live.com"].Name);
        }
        [TestMethod]
        public void TestKeyVaultDecryptCustomerData()
        {
            var customerDB = new CustomersDB(_tableClient);
            byte[] plainTextBytes = _cryptographyClient.Decrypt(EncryptionAlgorithm.RsaOaep, customerDB["alice@live.com"].CreditCardHash).Plaintext;
            Assert.AreEqual("11112222",Encoding.UTF8.GetString(plainTextBytes));
        }
        [TestCleanup]
        public void Cleanup() {
            _serviceClient.DeleteTableAsync(_tableName.ToLower()).Wait();
        }

    }
}
