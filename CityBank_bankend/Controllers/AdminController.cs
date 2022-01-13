using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using CityBank_bankend.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using common;
using Microsoft.AspNetCore.Cors;

namespace CityBank_bankend.Controllers
{
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        #region Api for creating BankAccount
        [HttpPost]
        [Route("/api/Admin/CreateAccount")]
        public Guid CreateCustomer( CustomerAccountModel cusomter)
        {
            if (cusomter == null)
            {
                return new Guid();
            }
            AdminRepositrory ar = AdminRepositrory.GetInstance();
            Guid g = ar.CreateAccount(cusomter.customer, cusomter.account, cusomter.balance); 
            return g;
        }
        #endregion

        #region Api for getting customer account
        [HttpGet]
        [Route("/api/Admin/GetCustomer/{id:int}")]
        public CustomerBankAccountModel GetCustomer(int id)
        {
            AdminRepositrory ar = AdminRepositrory.GetInstance();
            var result=ar.GetCustomer(id);
            return result;
        }
        #endregion

        #region Api for Updating account
        [HttpPut]
        [Route("/api/Admin/UpdateAccount")]
        public bool UpdateAccount(CustomerBankAccountModel Customer)
        {
            if (Customer == null)
            {
                return false;
            }
            AdminRepositrory ar = AdminRepositrory.GetInstance();
            bool result=ar.UpdateAccount(Customer.customer, Customer.account,Customer.balance);
            return true;
        }
        #endregion

        #region Api for deleting BankAccount
        [HttpDelete]
        [Route("/api/Admin/DeleteAccount/{id:int}")]
        public bool DeleteAccount(int id)
        {
            AdminRepositrory ar = AdminRepositrory.GetInstance();
            bool result = ar.DeleteAccount(id);
            return result;   
        }
        #endregion
    }
}
