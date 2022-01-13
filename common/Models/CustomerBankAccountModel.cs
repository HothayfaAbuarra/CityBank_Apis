using System;
using System.Collections.Generic;
using System.Text;

namespace common
{
    public class CustomerBankAccountModel
    {
        public CustomersModel customer { get; set; }
        public BankAccountsModel account { get; set; }
        public BalancesModel balance { get; set; }
    }
}
