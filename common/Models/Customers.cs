using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace common
{
    public class Customers
    {
        [Key]
        public Guid cuid { get; set; }
        public string Customer_name { get; set; }
        public string Customer_email { get; set; }
        public int Customer_identity { get; set; }
        public int Customer_age { get; set; }
        public int Customer_phone { get; set; }
        public bool Customer_status { get; set; }
        public List<BankAccounts> BankAccounts { get; set; }

    }
}
