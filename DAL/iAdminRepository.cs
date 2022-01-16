using System;
using System.Collections.Generic;
using System.Text;
using common;
namespace DAL
{
    public interface iAdminRepository
    {
        Guid CreateAccount(Customers customer,BankAccounts account,Balances balance);
        bool UpdateAccount(Customers customer,BankAccounts account,Balances balance);
        bool DeleteAccount(int identity_number);

    }
}
