using MindCology.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.ViewModels.Login
{
    public class LoginModel
    {
       


        [Key]
       
        [Required, MinLength(5), MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
       
    }
}
