using System;
using System.Collections.Generic;
using System.Text;
using common;
namespace DAL
{
    public interface iAdminRepository
    {
        Guid CreateAccount(CustomersModel customer,BankAccountsModel account,BalancesModel balance);
        bool UpdateAccount(CustomersModel customer,BankAccountsModel account,BalancesModel balance);
        bool DeleteAccount(int identity_number);

    }
}
