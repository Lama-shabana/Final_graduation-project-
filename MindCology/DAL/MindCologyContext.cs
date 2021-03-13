using Microsoft.EntityFrameworkCore;
using MindCology.DAL.Entities;
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
    }
}
