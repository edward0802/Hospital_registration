﻿//using InternetHospital.DataAccess.AppContextConfiguration;
using InternetHospital.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InternetHospital.DataAccess
{
    public class ApplicationContext: IdentityDbContext<User> //DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Diploma> Diplomas { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Status> Statuses { get; set; }
        //public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    string DB = "HospitalDb";
        //    string Username = "postgres";
        //    string Password = "1111";
        //    optionsBuilder.UseNpgsql($"Host=localhost;Port=5432;Database={DB};Username={Username};Password={Password}");
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.ApplyConfiguration(new AddressConfiguration());
        //    modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        //    modelBuilder.ApplyConfiguration(new PatientConfiguration());
        //    modelBuilder.ApplyConfiguration(new RoleConfiguration());
        //    modelBuilder.ApplyConfiguration(new SpecializationConfiguration());
        //    modelBuilder.ApplyConfiguration(new StatusConfiguration());
        //    modelBuilder.ApplyConfiguration(new UserConfiguration());
        //}
    }
}
