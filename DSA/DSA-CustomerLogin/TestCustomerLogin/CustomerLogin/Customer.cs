using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLogin
{
    public class Customer
    {
        private CryptoHelper _cryptoHelper = new();
        public Customer(string name,string email, string password, string creditCard)
        {
            Salt = RandomNumberGenerator.GetBytes(64);
            Name = name;
            Email = email;
            PasswordHash = _cryptoHelper.ComputeHash(password, Salt);
            CreditCardHash = _cryptoHelper.EncryptCreditCard(password,creditCard).Result;
        }

        public byte[] Salt;
        public string Name { get; }
        public string Email { get; }
        public byte[] PasswordHash { get; }
        public byte[] CreditCardHash { get; }
        public string ReadCreditCardPlainText(string password) {
            return _cryptoHelper.DecryptCreditCard(password, this.CreditCardHash).Result;
        }
    }


}
