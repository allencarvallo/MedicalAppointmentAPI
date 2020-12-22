using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppointmentAPI.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string PatientName { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string PatientEmail { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string PatientPassword { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
