using System;
using System.Collections.Generic;
using System.Text;
using common;
namespace DAL
{
    public interface IEmployeeRepository
    {
        Guid CreateAccount(EmployeesModel Employee);
        loggedEmployeeModel Login(string username, string password);
        bool DeleteAccount(int identityNumber);
        EmployeesModel UpdateEmployee(Guid Employee_id, UpdateEmployeeModel employee);
        EmployeesModel GetEmployee(Guid Employee_id);
    }
}
