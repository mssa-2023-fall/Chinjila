using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeRESTCall
{

    public class MortgageRepsone
    {
        public Monthly_Payment monthly_payment { get; set; }
        public Annual_Payment annual_payment { get; set; }
        public int total_interest_paid { get; set; }
    }

    public class Monthly_Payment
    {
        public int total { get; set; }
        public int mortgage { get; set; }
        public int property_tax { get; set; }
        public int hoa { get; set; }
        public int annual_home_ins { get; set; }
    }

    public class Annual_Payment
    {
        public int total { get; set; }
        public int mortgage { get; set; }
        public int property_tax { get; set; }
        public int hoa { get; set; }
        public int home_insurance { get; set; }
    }

}
