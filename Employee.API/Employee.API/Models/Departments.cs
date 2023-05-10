using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Models
{
    [Table("Departments")]
    public class Departments
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; } 
        [Required]
        [MinLength(3)]
        public string DepartmentName { get; set; }
        public Nullable<DateTime> CreatedDate { get; set; }
    }

    public class DasboardData
    {
        public int EmployeeCount { get; set; }
        public int DepartmentCount { get; set; }
        public int TodaysDepartments { get; set; }
    }


}
