using EmployeeDataAPI.DataContext;
using EmployeeDataAPI.JwtService;
using EmployeeDataAPI.Models;
using EmployeeDataAPI.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly EmpDbContextClass dbContext;

        public LoginController(IConfiguration configuration, EmpDbContextClass empDbContextClass)
        {
            this._configuration = configuration;
            this.dbContext = empDbContextClass;
        }

        [AllowAnonymous]
        [HttpPost("CreateNewEmployee")]
        public IActionResult CreateEmployee(EmployeeParameters emp)
        {
            if (dbContext.EmployeeData.Where(x => x.Email == emp.Email).FirstOrDefault() != null)
            {
                return Ok("Already Exists");
            }

            dbContext.EmployeeData.Add(emp);
            dbContext.SaveChanges();
            return Ok("Success");
        }

        [AllowAnonymous]
        [HttpPost("LoginEmployee")]
        public IActionResult LoginEmployee(Login login)
        {
            var employeeAvailable = dbContext.SignUpData.Where(x => x.Email == login.Email  && x.Pwd == login.Password).FirstOrDefault();
            if (employeeAvailable!=null)
            {
                return Ok(new JwtServiceClass(_configuration).GenerateToken(
                    
                    employeeAvailable.UserId.ToString(),
                    employeeAvailable.Name,
                    employeeAvailable.Email,
                    employeeAvailable.Gender
                    ));
            }
            return Ok("Failure");
        }

    }
}


////http://localhost:7208

