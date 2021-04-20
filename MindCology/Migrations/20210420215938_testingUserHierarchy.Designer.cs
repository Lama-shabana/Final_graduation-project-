﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MindCology.DAL;

namespace MindCology.Migrations
{
    [DbContext(typeof(MindCologyContext))]
    [Migration("20210420215938_testingUserHierarchy")]
    partial class testingUserHierarchy
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MindCology.DAL.Entities.MedicalHistoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("MentalOrPhysicalDisorder")
                        .HasColumnType("bit");

                    b.Property<string>("MentalOrPhysicalDisorderDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProvidedWithMentalHealthServices")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeekingHelpFor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionsLanguage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TherapistGender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ThinkAboutHarmingYourself")
                        .HasColumnType("bit");

                    b.Property<string>("ThinkAboutHarmingYourselfDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TraumaticExperience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UnderMedications")
                        .HasColumnType("bit");

                    b.Property<string>("UnderMedicationsDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("MedicalHistory");
                });

            modelBuilder.Entity("MindCology.DAL.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilledMedicalForm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MindCology.DAL.Entities.PatientEntity", b =>
                {
                    b.HasBaseType("MindCology.DAL.Entities.UserEntity");

                    b.Property<bool>("FilledMedicalHistoryForm")
                        .HasColumnType("bit");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("MindCology.DAL.Entities.MedicalHistoryEntity", b =>
                {
                    b.HasOne("MindCology.DAL.Entities.UserEntity", "User")
                        .WithOne("MedicalHistory")
                        .HasForeignKey("MindCology.DAL.Entities.MedicalHistoryEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MindCology.DAL.Entities.PatientEntity", b =>
                {
                    b.HasOne("MindCology.DAL.Entities.UserEntity", null)
                        .WithOne()
                        .HasForeignKey("MindCology.DAL.Entities.PatientEntity", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MindCology.DAL.Entities.UserEntity", b =>
                {
                    b.Navigation("MedicalHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
