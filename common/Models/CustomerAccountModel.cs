using System;
using System.Collections.Generic;
using System.Text;

namespace common
{
    public class CustomerAccountModel
    {
        public CustomersModel customer { get; set; }
        public BankAccountsModel account { get; set; }
        public BalancesModel balance { get; set; }
    }
}
