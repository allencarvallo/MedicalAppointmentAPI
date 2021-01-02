using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedicalAppointmentAPI.Models;
using Microsoft.AspNetCore.Cors;

namespace MedicalAppointmentAPI.Controllers
{
    [Route("MedicalAppointment/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly MedicalAppointmentContext _context;

        public AppointmentsController(MedicalAppointmentContext context)
        {
            _context = context;
        }

        // GET: api/Appointments
        [HttpGet]
        [Route("patient/{patientid}")]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAppointments(int patientid)
        {
            return await _context.Appointments
                .Where(appointment => appointment.PatientId == patientid)
                .Include(b => b.Doctor)
                .Include(c => c.Patient)
                .ToListAsync();
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return appointment;
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return BadRequest();
            }

            //_context.Entry(appointment).State = EntityState.Modified;
            var appointmentUpdate = _context.Appointments.First(a => a.AppointmentId == id);
            appointmentUpdate.Description = appointment.Description;
            appointmentUpdate.DoctorId = appointment.DoctorId;
            appointmentUpdate.AppointmentTime = appointment.AppointmentTime;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            int maxToken = await _context.Appointments.MaxAsync(a => (int?)a.Token) ?? 100;
            appointment.Token = maxToken + 1;

            _context.Appointments.Add(appointment);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppointment", new { id = appointment.AppointmentId }, appointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }
    }
}
