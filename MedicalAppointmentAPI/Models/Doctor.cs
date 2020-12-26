using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointmentAPI.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string DoctorName { get; set; }
        
        [Column(TypeName = "varchar(30)")]
        public string DoctorEmail { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string DoctorPassword { get; set; }

        //public ICollection<Appointment> Appointments { get; set; }
    }
}
