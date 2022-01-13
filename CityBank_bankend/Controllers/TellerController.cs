using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBank_bankend.Models;
using DAL;
using common;
namespace CityBank_bankend.Controllers
{
    [ApiController]
    public class TellerController
    {
        #region Api for Deposit
        [HttpPut]
        [Route("/api/teller/deposit")]
        public double Deposit(DepositWithdrawModel account)
        {
            TellerRepository tr = new TellerRepository();
            double result= tr.Deposit(account.id, account.mony);
            return result;
        }
        #endregion

        #region Api for Withdraw
        [HttpPut]
        [Route("/api/teller/withdraw")]
        public string withdraw(DepositWithdrawModel account)
        {
            TellerRepository tr = new TellerRepository();
            string result = tr.Withdraw(account.id, account.mony);
            return result;
        }
        #endregion
    }
}
