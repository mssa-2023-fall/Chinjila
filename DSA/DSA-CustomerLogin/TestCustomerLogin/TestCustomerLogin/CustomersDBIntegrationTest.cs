using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Azure.Security.KeyVault.Keys.Cryptography;

namespace CustomerLogin.Tests
{
    [TestClass()]
    public class CustomersDBIntegrationTests
    {
        private string _tenantID;
        private string _clientID;
        private string _ClientSecret;
        private string _tableConnStr;
        private string _tableName;
        private string _keyVaultUri;
        private TableServiceClient _tableServiceClient;
        private KeyClient _keyClient;
        private CryptographyClient _key;
        private CustomersDB _customers;
        [TestInitialize]
        public void init()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .Build();
            _tenantID = config["Azure:TenantID"];
            _clientID = config["Azure:ClientID"];
            _ClientSecret = config["Azure:ClientSecret"];
            _tableConnStr = config["Azure:TableConnStr"];
            _tableName = config["Azure:TableName"] + Guid.NewGuid().ToString().Substring(0, 4);//append guid to avoid delay in deleting the table
            _keyVaultUri = config["Azure:KeyVaultUri"];

            //code to create a table: _tableName
            _tableServiceClient = new TableServiceClient(_tableConnStr);
            _tableServiceClient.CreateTableIfNotExists(_tableName);

            //create key client
            _keyClient = new KeyClient(new Uri(_keyVaultUri), new ClientSecretCredential(_tenantID, _clientID, _ClientSecret));
            _key = _keyClient.GetCryptographyClient("mssa");

            TableClient _testTable = _tableServiceClient.GetTableClient(_tableName);
            _customers = new CustomersDB(_testTable,_key);//instantiate _customer with Azure backing.
        }
        [TestMethod()]
        public void LoginSuccessTest()
        {
            Assert.IsTrue(_customers.Login("alice@live.com", "password"));
        }
        [TestMethod()]
        public void LoginFailsWithWrongPasswordTest()
        {
            Assert.IsFalse(_customers.Login("alice@live.com", "badpassword"));
        }
        [TestMethod()]
        public void LoginFailsWithWrongUserNameTest()
        {
            Assert.IsFalse(_customers.Login("noone@live.com", "password"));
        }
        [TestMethod()]
        public void TestExistingCustomersCountEquals3()
        {
            Assert.AreEqual(3, _customers.Count);
        }
        [TestMethod()]
        public void PasswordHashShouldBeDifferent()
        {
            Assert.AreNotEqual(_customers["alice@live.com"].PasswordHash, _customers["bob@live.com"].PasswordHash);
            Assert.AreNotEqual(_customers["alice@live.com"].PasswordHash, _customers["charlie@live.com"].PasswordHash);
        }
        [TestMethod()]
        public void TestCreditCardDecryption()
        {
            Assert.AreEqual("11112222", _customers.ReadCreditCard("alice@live.com", "password"));
        }
     
        [TestMethod()]
        public void TestCreditCardDecryptionFailsWithNoUserFound()
        {
            Assert.ThrowsException<Exception>(() => _customers.ReadCreditCard("noone@live.com", "password"));
        }

    }
}