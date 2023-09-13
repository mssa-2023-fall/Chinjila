using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLogin
{
    public class CryptoHelper
    {
        public byte[] ComputeHash(string input, byte[] salt) { 
        }

        public bool VerifyHash(string clearPasswor,byte[] passwordHash, byte[] salt) { 
        }

        public string DecryptCreditCard(string clearPasswor, byte[] passwordHash, string creditCard)
        {
        }
        public byte[] EncryptCreditCard(string clearPasswor, byte[] passwordHash, string creditCard)
        {
        }

    }
}
