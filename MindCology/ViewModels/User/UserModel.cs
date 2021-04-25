using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.ViewModels.User
{
    public class UserModel
    {
        [Required, MinLength (2), MaxLength(20)]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }


        [Required]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

      
        [Required]
        public string UserType { get; set; }








    }
}
