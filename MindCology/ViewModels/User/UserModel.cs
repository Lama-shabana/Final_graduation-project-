﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.ViewModels.User
{
    public class UserModel
    {
        [ MinLength (2), MaxLength(20)]
        public string FirstName { get; set; }
        
       
        public string LastName { get; set; }
        
        public string PhoneNumber { get; set; }


 
        public string Email { get; set; }

    
        public string Gender { get; set; }

       
        public int Age { get; set; }

        public string Username { get; set; }


        public string Password { get; set; }

      
        public string UserType { get; set; }

        public bool Active { get; set; }






    }
}
