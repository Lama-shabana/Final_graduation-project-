using MindCology.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.ViewModels.Login
{
    public class LoginViewModel


    {
        public LoginViewModel(UserEntity user, string token)
        {
           
            Username = user.Username;
            Token = token;
        }

        

        public int Id { get; internal set; }
        public string Username { get; set; }
        public string Password { get; set; }
      
       public string Token { get; }



      
        
    }
}
