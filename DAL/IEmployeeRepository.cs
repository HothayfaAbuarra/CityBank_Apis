using System;
using System.Collections.Generic;
using System.Text;
using common;
namespace DAL
{
    public interface IEmployeeRepository
    {
        Guid CreateAccount(Employees Employee);
        loggedEmployee Login(string username, string password);
        bool DeleteAccount(int identityNumber);
        Employees UpdateEmployee(Guid Employee_id, UpdateEmployee employee);
        Employees GetEmployee(Guid Employee_id);
    }
}
