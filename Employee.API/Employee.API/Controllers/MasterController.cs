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
    [Route("api/master")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class MasterController : Controller
    {
        private readonly EmployeeDbContext _db;
        public MasterController(EmployeeDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("GetDepartment")]
        public List<Departments> getAllDepartments()
        {
            var list = _db.Departments.ToList();
            return list;

        }

        [HttpPost]
        [Route("addDept")]
        public Departments AddDepartment(Departments obj)
        {
            if (!ModelState.IsValid)
            {
                obj.DepartmentName = "Form Not Valid";
            }
            else
            {
                _db.Departments.Add(obj);
                _db.SaveChanges();
            }
            return obj;
        }

    }
}
