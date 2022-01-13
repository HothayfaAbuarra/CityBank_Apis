using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using common;
using DAL;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

namespace CityBank_bankend.Controllers
{
    [ApiController]
    public class EmployeeController
    {
        #region Api for Create Employee
        [HttpPost]
        [Route("/api/employee/create")]
        public Guid CreateEmployee(EmployeesModel employee)
        {
            EmployeeRepository er = new EmployeeRepository();
            var result=er.CreateAccount(employee);
            if (result == null)
            {
                return new Guid();
            }
            else
            {
                return result;
            }
        }
        #endregion

        #region Api for Login
        [HttpPost]
        [Route("/api/employee/auth")]
        public loggedEmployeeModel LoginAuth(LoginModel user)
        {
            EmployeeRepository er = new EmployeeRepository();
            var result = er.Login(user.username,user.password);
            
            if (result == new loggedEmployeeModel { })
            {
                return new loggedEmployeeModel { };
            }
            var mySecret = "asdv234234^&%&^%&^hjsdfb2%%%";
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, result.Employee_id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddSeconds(10),
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new loggedEmployeeModel { token= tokenHandler.WriteToken(token),Department_name =result.Department_name};
        }
        #endregion

        #region Api for Get employee to update
        [HttpGet]
        [Route("/api/employee/GetEmployee/{Employee_id:Guid}")]
        public EmployeesModel GetEmployee(Guid Employee_id)
        {
            EmployeeRepository er = new EmployeeRepository();
            var result = er.GetEmployee(Employee_id);
            if(result==new EmployeesModel { })
            {
                return new EmployeesModel { };
            }
            else
            {
                return result;
            }
        }
        #endregion

        #region Api for update the employee
        [HttpPut]
        [Route("/api/employee/UpdateEmployee/{employee_id:Guid}")]
        public EmployeesModel UpdateEmployee(string employee_id, UpdateEmployeeModel emp)
        {
            EmployeeRepository er = new EmployeeRepository();
            var result=er.UpdateEmployee(Guid.Parse(employee_id),emp);
            if(result==new EmployeesModel { })
            {
                return new EmployeesModel { };
            }
            else
            {
                return result;
            }
        }
        #endregion
    }
}
