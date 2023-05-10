using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Models
{
    [Table("Employees")]
    public class EmployeeMaster
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpContactNo { get; set; }
        public string EmpEmailId { get; set; }
        public string EmpState { get; set; }
    }


}
