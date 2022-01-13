using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Linq;
using common;

namespace DAL
{
    public class AdminRepositrory : iAdminRepository
    {
        private static AdminRepositrory bankrepo;
        BankdbContext db = new BankdbContext();
        private AdminRepositrory()
        {

        }
        public static AdminRepositrory GetInstance()
        {
            if (bankrepo == null)
            {
                bankrepo = new AdminRepositrory();
            }
            return bankrepo;
        }
        #region GetAllBankAccounts Method
        public List<CustomersModel> Getdata()
        {
            var Customers = db.Customers.Select(s=>s).ToList();
            return Customers;
            
        }
        #endregion

        #region Create Account Method
        /*
         Input:IdentityNumber, email,name,age,balance,type
         output:if sucess returned true,the unique key for the newly created account and if failed returned false
         */
        public Guid CreateAccount(CustomersModel customer,BankAccountsModel account,BalancesModel balance)
        {                 
            try
            {
                var result = Getdata();
                foreach (CustomersModel ccustomer in result)
                {
                    if (ccustomer.Customer_identity == customer.Customer_identity)
                    {
                        return new Guid();
                    }
                }
                Guid gg = Guid.NewGuid();
                //Add a customer
                customer.cuid = gg;
                customer.Customer_status = true;
                db.Customers.Add(customer);
                db.SaveChanges();

                //add an account
                account.Customerscuid = gg;
                account.Account_Status = true;
                var a= db.BankAccounts.Add(account);
                db.SaveChanges();

                //add a balance
                balance.Account_id = a.Entity.BankAccount_id;
                db.Balances.Add(balance);
                db.SaveChanges();

                return customer.cuid;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return new Guid();
                
            }
            
        }
        #endregion

        #region Get Customer By identityNumber Method
        public CustomerBankAccountModel GetCustomer(int identity)
        {
            try
            {
                var result = (from cust in db.Customers
                             from acc in db.BankAccounts
                             from bala in db.Balances
                             where cust.Customer_identity== identity && acc.Customerscuid == cust.cuid && bala.Account_id==acc.BankAccount_id
                             select new { cust, acc,bala }).FirstOrDefault();
                if(result==null)
                {
                   return new CustomerBankAccountModel { account=null,customer=null};
                }
                else
                {
                    CustomerBankAccountModel customerr = new CustomerBankAccountModel { customer = result.cust, account = result.acc,balance=result.bala };
                    return customerr;
                }
            }catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region Update Account Method
        /*
         Input:IdentityNumber, email,name,age,balance,type
         output:if sucess returned true and if failed returned false
         */
        public bool UpdateAccount(CustomersModel customer,BankAccountsModel account,BalancesModel Balance)
        {
            try
            {
                var result = from cust in db.Customers
                                where cust.Customer_identity == customer.Customer_identity
                                select cust;
                if (result.Count() == 0)
                {
                    return false;
                }
                else
                { 
                    var updated = (from cust in db.Customers
                                    from acc in db.BankAccounts
                                    from bala in db.Balances
                                    where cust.Customer_identity == customer.Customer_identity && acc.Customerscuid == cust.cuid &&bala.Account_id==acc.BankAccount_id
                                    select new { cust, acc,bala }).FirstOrDefault();
                    //update customer
                    updated.cust.Customer_email = customer.Customer_email;
                    updated.cust.Customer_age = customer.Customer_age;
                    updated.cust.Customer_name = customer.Customer_name;
                    updated.cust.Customer_phone = customer.Customer_phone;

                    //update account
                    updated.acc.Account_type = account.Account_type;
                    updated.acc.Account_Date = account.Account_Date;

                    //update balance
                    updated.bala.balance = Balance.balance;
                    db.SaveChanges();
                }
                /*
                string auditFilePath = @"C:\Users\Habuarra\source\repos\BankSystem\BankSystem\AuditFile.txt";
                File.AppendAllText(auditFilePath, $"Update the account that has identitynumber: {customer.Customer_identity}," +
                                                            $"email: {customer.Customer_email}, name: {customer.Customer_name}, age:{customer.Customer_age}," +
                                                            $" AccountType: {account.Account_type}, onDate:{account.Account_Date}" + Environment.NewLine);*/
                return true;
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return false;
            }
        }
        #endregion

        #region Delete Account Method
        /*
         Input:IdentityNumber
         output:if sucess returned true and if failed returned false
         */
        public bool DeleteAccount(int identity_num)
        {
            try
            {
                var result=(from cust in db.Customers
                            from acc in db.BankAccounts
                            where cust.Customer_identity==identity_num && acc.Customerscuid==cust.cuid
                            select new { cust , acc}).FirstOrDefault();
                if (result != null)
                {
                    result.cust.Customer_status = false;
                    result.acc.Account_Status = false;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                return false;
            }
        }
        #endregion
    }
}