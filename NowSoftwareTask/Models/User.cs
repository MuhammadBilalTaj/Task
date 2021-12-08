using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NowSoftwareTask.Models
{
    public class User
    {
        public int id { get; set; }

        [Required]
        
        public string FirstName { get; set; }

        [Required]
        
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public string Role { get; set; }

        public string UserName { get; set; }



    }
}
