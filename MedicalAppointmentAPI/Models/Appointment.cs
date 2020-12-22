﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointmentAPI.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Column(TypeName ="varchar(200)")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string AppointmentTime { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Token { get; set; }

        public bool Status { get; set; }


        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}