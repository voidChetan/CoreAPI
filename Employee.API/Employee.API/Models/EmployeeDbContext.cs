using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Models
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }

        public DbSet<EmployeeMaster> EmployeeMasters { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }


    }
}
