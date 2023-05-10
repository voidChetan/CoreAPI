using Employee.API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Controllers
{
    [Route("api/Registration")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly EmployeeDbContext _db;
        public RegistrationController(EmployeeDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Route("Register")]
        public UserMaster AddUser(UserMaster obj)
        {
            _db.UserMasters.Add(obj);
            _db.SaveChanges();
            return obj;
        }

        [HttpPost]
        [Route("Login")]
        public LoginModel Login(LoginModel obj)
        {
            var isUserExist = _db.UserMasters.SingleOrDefault(m => m.UserName == obj.UserName && m.Password == obj.Password);
            if(isUserExist != null)
            {
                obj.UserId = isUserExist.UserId;
                obj.Result = true;
                obj.Message = "Login Success";

            } else
            {
                obj.Result = false;
                obj.Message = "UserName or Password is Wrong";

            }
            return obj;
        }
    }
}
