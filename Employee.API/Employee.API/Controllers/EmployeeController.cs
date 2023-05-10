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
    [Route("api/Employee")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeDbContext _db;
        public EmployeeController(EmployeeDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public List<EmployeeMaster> GetAllEmployee()
        {
            var list = _db.EmployeeMasters.ToList();
            return list;
        }

        [HttpGet]
        [Route("getEmployeeById")]
        public EmployeeMaster getEmpById(int id)
        {
            var record = _db.EmployeeMasters.SingleOrDefault(m => m.EmpId == id);
            if (record != null)
            {
                return record;
            }
            else
            {
                EmployeeMaster obj = new EmployeeMaster();
                return obj;
            }

        }

        [HttpPost]
        [Route("AddEmp")]
        public EmployeeMaster addEmployee(EmployeeMaster empObj)
        {
            _db.EmployeeMasters.Add(empObj);
            _db.SaveChanges();
            return empObj;
        }

        [HttpPut]
        [Route("updateEmpl")]
        public EmployeeMaster updateEmployee(EmployeeMaster empObj)
        {
            var record = _db.EmployeeMasters.Single(m => m.EmpId == empObj.EmpId);
            record.EmpContactNo = empObj.EmpContactNo;
            record.EmpEmailId = empObj.EmpEmailId;
            record.EmpName = empObj.EmpName;
            record.EmpState = empObj.EmpState;
            _db.SaveChanges();
            return record; 
        }
        [HttpDelete]
        [Route("deleteEmpById")]
        public bool deleteEmp(int id)
        {
            var record = _db.EmployeeMasters.Single(emp => emp.EmpId == id);
            _db.EmployeeMasters.Remove(record);
            _db.SaveChanges();
            return true;
        }


    }
}
