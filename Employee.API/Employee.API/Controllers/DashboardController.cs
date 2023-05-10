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
    [Route("api/Dasboard")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly EmployeeDbContext _db;
        public DashboardController(EmployeeDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("GetDashboardData")]
        public DasboardData getDashBoard()
        {
            DasboardData _obj = new DasboardData();
            _obj.DepartmentCount = _db.Departments.Count();
            _obj.EmployeeCount = _db.EmployeeMasters.Count();
            _obj.TodaysDepartments = _db.Departments.Where(m => m.CreatedDate.Value.Date == DateTime.Now.Date).Count();
            return _obj;
        }
    }
}
