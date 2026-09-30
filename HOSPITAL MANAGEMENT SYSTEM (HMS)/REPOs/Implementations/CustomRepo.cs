using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Data;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Implementations
{
    public class CustomRepo<T> : ICustomRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        public CustomRepo(AppDbContext context)
        {
            _context = context;
        }
        public List<Doctor> DoctorsDetais()
        {
            var v = _context.Doctors.ToList();
            foreach(Doctor doctor in v)
            {
                var dep = _context.Departments.Find(doctor.DepartmentId);
                doctor.Department = new Department()
                {
                    DepartmentId = dep.DepartmentId,
                    Name = dep.Name,
                    Location = dep.Location
                };
            }
            return v;
        }
        public List<Patient> PatientHistory()
        {
            var v = _context.Patients.ToList();
            foreach(Patient doctor in v)
            {
                var dep = _context.Appointments.Where(e => e.PatientId == doctor.PatientId).Select(e => new {
                    e.Status,
                    e.AppointmentDate,
                    e.DoctorId,
                    e.PatientId,
                    e.MedicalRecordId
                }).ToList();
            }
            return v;
        }
    }
}
