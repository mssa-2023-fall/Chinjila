using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLogin
{
    public class Customer
    {
        public Customer(string name,string email, byte[] passwordHash, byte[] creditCardHash)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            CreditCardHash = creditCardHash;
        }

        public string Name { get; }
        public string Email { get; }
        public byte[] PasswordHash { get; }
        public byte[] CreditCardHash { get; }
    }
}
