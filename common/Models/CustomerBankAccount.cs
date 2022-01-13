using System;
using System.Collections.Generic;
using System.Text;

namespace common
{
    public class CustomerBankAccount
    {
        public Customers customer { get; set; }
        public BankAccounts account { get; set; }
        public Balances balance { get; set; }
    }
}
