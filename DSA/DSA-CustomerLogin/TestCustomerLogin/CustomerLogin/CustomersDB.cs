using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLogin
{
    public class CustomersDB
    {
        private Dictionary<string, Customer> _customers=new ();
        public CustomersDB()
        {
            
        }
        public bool Login(string username, string password) {
            return false;
        }

        public string ReadCreditCard(string username, string password)
        {
            return string.Empty;
        }

    }
}
