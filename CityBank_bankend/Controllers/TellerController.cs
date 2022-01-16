using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityBank_bankend.Models;
using DAL;
using common;
using Microsoft.AspNetCore.Authorization;

namespace CityBank_bankend.Controllers
{
    [ApiController]
    public class TellerController
    {
        #region Api for Deposit
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [Route("/api/teller/deposit")]
        public double Deposit(DepositWithdraw account)
        {
            TellerRepository tr = new TellerRepository();
            double result= tr.Deposit(account.id, account.mony);
            return result;
        }
        #endregion

        #region Api for Withdraw
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [Route("/api/teller/withdraw")]
        public string withdraw(DepositWithdraw account)
        {
            TellerRepository tr = new TellerRepository();
            string result = tr.Withdraw(account.id, account.mony);
            return result;
        }
        #endregion
    }
}
