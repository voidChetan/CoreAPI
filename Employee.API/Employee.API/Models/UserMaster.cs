using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Models
{
    [Table("UserMaster")]
    public class UserMaster
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }

    }

    public class LoginModel
    { 
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool Result { get; set; }
        public string Message { get; set; }

    }
}
