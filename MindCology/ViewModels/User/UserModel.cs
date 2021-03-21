using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.ViewModels.User
{
    public class UserModel
    {
        [Required, MinLength (5), MaxLength(20)]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }
       
    }
}
