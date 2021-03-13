using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MindCology.ViewModels.User
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public int Password { get; set; }
        public string Username { get; set; }

    }
}
