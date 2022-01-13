using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using common;
using System.Linq;
namespace DAL
{
    public class TellerRepository : iTellerRepository
    {
        BankdbContext db = new BankdbContext();

        #region Method for deposit
        /*
         *Input:IdentityNumber and mony
         *output:if sucess returned true,increased the balance of the account by the entered mony and if failed returned false
         */
        public double Deposit(int identity_number,double mony)
        {
            try
            {
                var result = (from customer in db.Customers
                                where customer.Customer_identity == identity_number
                                select customer).FirstOrDefault();
                   
                if (result == null)
                {
                    return new double();
                }
                else
                {
                    var Balance = (from bal in db.Balances
                                   from acc in db.BankAccounts
                                   where acc.Customerscuid == result.cuid
                                   where bal.Account_id == acc.BankAccount_id
                                   select bal).FirstOrDefault();
                    Balance.balance = Balance.balance + mony;
                    db.SaveChanges();
                    return Balance.balance;
                }
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region Method for withdraw
        /*
         *Input:IdentityNumber and mony
         *output:if sucess returned true,decreased the balance of the account by the entered mony and if failed returned false,
         *if the result of the (balance-mony) returned false
         */
        public string Withdraw(int identity_number, double mony)
        {
            try
            {
                var result = (from customer in db.Customers
                                where customer.Customer_identity == identity_number
                                select customer).FirstOrDefault();

                if (result == null)
                {
                    return "there is no account for this identity number";
                }
                else
                {
                    var Balance = (from bal in db.Balances
                                   from acc in db.BankAccounts
                                   where acc.Customerscuid == result.cuid
                                   where bal.Account_id == acc.BankAccount_id
                                   select bal).FirstOrDefault();
                    Balance.balance = Balance.balance - mony;
                    if (Balance.balance < 0)
                    {
                        return "you cant withdraw because the result balance is negative";
                    }
                    db.SaveChanges();
                    return Balance.balance.ToString();
                }
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

    }
}
