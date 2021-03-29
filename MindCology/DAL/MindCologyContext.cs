using Microsoft.EntityFrameworkCore;
using MindCology.DAL.Entities;
using MindCology.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MindCology.DAL
{
    public class MindCologyContext : DbContext
    {
        public MindCologyContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserEntity> User { get; set; }
        //public DbSet<LoginEntity> Login { get; set; }

        internal object Authenticate(LoginModel model)
        {
            throw new NotImplementedException();
        }

        internal object GetAll()
        {
            throw new NotImplementedException();
        }

       
    }
}
