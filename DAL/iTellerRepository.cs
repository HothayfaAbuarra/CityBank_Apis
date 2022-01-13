using System;
using System.Collections.Generic;
using System.Text;
using common;
namespace DAL
{
    public interface iTellerRepository
    {
        double Deposit(int identity_number,double mony);
        string Withdraw(int identity_numebr,double mony);
    }
}
