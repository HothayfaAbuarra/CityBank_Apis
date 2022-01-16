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
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;


namespace CityBank_bankend.Controllers
{
    
    [ApiController]
    
    public class EmployeeController
    {
        private readonly IConfiguration _configuration;
        
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private string GenerateJwtToken(string userName)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", userName) }),
                Expires = DateTime.UtcNow.AddSeconds(30),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #region Api for Create Employee
        [HttpPost]
        [Route("/api/employee/create")]
        public Guid CreateEmployee(Employees employee)
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
        public loggedEmployee LoginAuth(LoginModel user)
        {
            EmployeeRepository er = new EmployeeRepository();
            var result = er.Login(user.username,user.password);
            
            if (result == new loggedEmployee { })
            {
                return new loggedEmployee { };
            }

            
            var tokenString = GenerateJwtToken(result.Employee_id.ToString());
            return new loggedEmployee { token= tokenString, Department_name =result.Department_name};
        }
        #endregion

        #region Api for Get employee to update
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        [Route("/api/employee/GetEmployee/{Employee_id:Guid}")]
        public Employees GetEmployee(Guid Employee_id)
        {
            EmployeeRepository er = new EmployeeRepository();
            var result = er.GetEmployee(Employee_id);
            if(result==new Employees { })
            {
                return new Employees { };
            }
            else
            {
                return result;
            }
        }
        #endregion

        #region Api for update the employee
        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        [Route("/api/employee/UpdateEmployee/{employee_id:Guid}")]
        public Employees UpdateEmployee(string employee_id, UpdateEmployee emp)
        {
            EmployeeRepository er = new EmployeeRepository();
            var result=er.UpdateEmployee(Guid.Parse(employee_id),emp);
            if(result==new Employees { })
            {
                return new Employees { };
            }
            else
            {
                return result;
            }
        }
        #endregion
    }
}
