﻿using Azure;
using Azure.Data.Tables;
using Azure.Security.KeyVault.Keys.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLogin
{
    public class Customer : ITableEntity
    {
        private CryptoHelper _cryptoHelper = new();
        public Customer(string name, string email, string password, string creditCard, CryptographyClient? _cryptographyClient=null )
        {
            Salt = RandomNumberGenerator.GetBytes(64);
            Name = name;
            Email = email;
            PasswordHash = _cryptoHelper.ComputeHash(password, Salt);
            if (_cryptographyClient != null)
            { 
                CreditCardHash = _cryptographyClient.Encrypt(EncryptionAlgorithm.RsaOaep,Encoding.UTF8.GetBytes(creditCard)).Ciphertext;
            }
            else 
            { 
                CreditCardHash = _cryptoHelper.EncryptCreditCard(password, creditCard).Result; }
            

        }
        public Customer()
        {

        }

        public byte[] Salt;
        public string Name;
        public string Email;
        public byte[] PasswordHash;
        public byte[] CreditCardHash;

        public string PartitionKey { get => Email; set => this.Email = value; }
        public string RowKey { get => Name; set => this.Name = value; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }


    }
}
