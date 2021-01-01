﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointmentAPI.Models
{
    public class MedicalAppointmentContext: DbContext
    {
        public MedicalAppointmentContext(DbContextOptions<MedicalAppointmentContext> options) : base(options)
        {
            this.Database.Migrate();
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=MedicalAppointmentDB;Username=postgres;Password=carvallo");
    }
}
