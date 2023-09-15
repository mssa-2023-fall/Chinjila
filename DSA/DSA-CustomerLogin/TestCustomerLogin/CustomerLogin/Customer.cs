using Azure;
using Azure.Data.Tables;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Keys.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLogin
{
    public class Customer:ITableEntity
    {
        private CryptoHelper _cryptoHelper = new();
        public Customer()
        {
            
        }
        public Customer(string name, string email, string password, string creditCard) : this(name, email, password, creditCard, null)
        {
        }
        public Customer(string name, string email, string password, string creditCard,CryptographyClient cryptographyClient)
        {
            Salt = RandomNumberGenerator.GetBytes(64);
            Name = name;
            Email = email;
            PasswordHash = _cryptoHelper.ComputeHash(password, Salt);
            if (cryptographyClient is null ){ CreditCardHash = _cryptoHelper.EncryptCreditCard(password, creditCard).Result; }
            else {
                CreditCardHash = cryptographyClient.EncryptAsync(
                    EncryptionAlgorithm.RsaOaep,
                    Encoding.UTF8.GetBytes(creditCard)).Result.Ciphertext;
            }
        }

        public byte[] Salt;
        public string Name { get; }
        public string Email { get; }
        public byte[] PasswordHash { get; }
        public byte[] CreditCardHash { get; }
   
    }


    }
}
