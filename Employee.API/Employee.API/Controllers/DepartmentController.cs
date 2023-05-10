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
    [Route("api/Department")]
    [ApiController] 
    [DisableCors]
    public class DepartmentController : ControllerBase
    {
        private readonly EmployeeDbContext _db;
        public DepartmentController(EmployeeDbContext db)
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
        [Route("CreateNewDepartment")]
        public Departments AddDepartment(Departments obj)
        {
            if(!ModelState.IsValid)
            {
                obj.DepartmentName = "Form Not Valid";
            } else
            {
                _db.Departments.Add(obj);
                _db.SaveChanges(); 
            }
            return obj; 
        }

        [HttpPut]
        [Route("updateDepartment")]
        public Departments upddateDept([FromBody]  Departments obj)
        {
            var record = _db.Departments.Single(m => m.DeptId == obj.DeptId);
            record.DepartmentName = obj.DepartmentName;
            _db.SaveChanges();
            return record;

        }

        [HttpGet]
        [Route("deletDeptById")]
        public Departments deletDeptById(int id)
        {
            var record = _db.Departments.Single(m => m.DeptId == id);
            _db.Departments.Remove(record);
            _db.SaveChanges();
            return record;

        }


        public void addnum()
        {

        }

        public int addNUm2()
        {
            return 1;
        }


    }
}
