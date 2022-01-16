using common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DAL
{
    public class EmployeeRepository : IEmployeeRepository
    {
        BankdbContext db = new BankdbContext();

        #region Method for Insert Employee to DB
        public Guid CreateAccount(Employees Employee)
        {
           
            try
            {
                var result = (from emp in db.Employees
                                where emp.Employee_identity == Employee.Employee_identity || emp.Employee_username==Employee.Employee_username
                                select emp).FirstOrDefault();
                if (result==null)
                {
                    string hasedPassword = BCrypt.Net.BCrypt.HashPassword(Employee.Employee_password);
                    Employee.Employee_password = hasedPassword;
                    Guid guid = Guid.NewGuid();
                    Employee.Employee_id = guid;
                    Employee.Employee_Status = true;
                    db.Add(Employee);
                    db.SaveChanges();
                    return guid;
                }
                else
                {
                    return new Guid();
                }         
                    
            }
            catch (Exception e)
            {
                throw new Exception("Exciption:"+ e.Message.ToString());
            }
            
        }
        #endregion

        #region Method for Inactive the account
        public bool DeleteAccount(int identityNumber)
        {
            try
            {
                var resultEmployee = (from employee in db.Employees
                                      where employee.Employee_identity == identityNumber
                                      select employee).FirstOrDefault();
                if (resultEmployee==null)
                {
                    return false;
                }

                if (resultEmployee.Employee_Status == false)
                {
                    return false;
                }
                resultEmployee.Employee_Status = false;
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                throw new Exception("Exciption :" + e.InnerException.Message.ToString());
            }
            
        }
        #endregion

        #region Method for test login
        public loggedEmployee Login(string username,string password)
        {
            try
            {
                var result = (from employee in db.Employees
                              where employee.Employee_username == username
                              select employee).FirstOrDefault();
                if (result == null)
                {
                    return new loggedEmployee { };
                }

                bool validCredintials = BCrypt.Net.BCrypt.Verify(password,result.Employee_password);
                if (validCredintials)
                {
                    var departmentResult = (from department in db.Departments
                                            where department.Department_id == result.Department_id
                                            select department.Department_name).FirstOrDefault();
                    return new loggedEmployee {Department_name=departmentResult,Employee_id=result.Employee_id};
                }
                else
                {
                    return new loggedEmployee { };
                }
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region Method for get employee
        public Employees GetEmployee(Guid Employee_id)
        {
            try
            {
                var result = (from emp in db.Employees
                              where Employee_id == emp.Employee_id
                              select emp).FirstOrDefault();
                if (result == null)
                {
                    return new Employees { };
                }
                else
                {
                    result.Employee_password = "";
                    return result;
                }
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region Method for update employee account
        public Employees UpdateEmployee(Guid Emplyee_id, UpdateEmployee employee)
        {
            try
            {
                var result = (from emp in db.Employees
                              where emp.Employee_id == Emplyee_id
                              select emp).FirstOrDefault();
                if (result == null)
                {
                    return new Employees { };
                }
                else
                {
                    result.Employee_username = employee.Employee_username;
                    result.Employee_Email = employee.Employee_Email;
                    result.Employee_identity = employee.Employee_identity;
                    db.SaveChanges();
                    return result;
                }
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
    }
}
