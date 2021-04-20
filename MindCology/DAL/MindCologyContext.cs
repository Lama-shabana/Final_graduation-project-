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
        public DbSet<PatientEntity> Patient { get; set; }

        public DbSet<MedicalHistoryEntity> MedicalHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalHistoryEntity>()
                .HasOne(p=> p.Patient)
                .WithOne(p=> p.MedicalHistory)
                .HasForeignKey<MedicalHistoryEntity>(p => p.PatientId);

            modelBuilder.Entity<UserEntity>().ToTable("User");
            modelBuilder.Entity<PatientEntity>().ToTable("Patient");

        }
    }
}
