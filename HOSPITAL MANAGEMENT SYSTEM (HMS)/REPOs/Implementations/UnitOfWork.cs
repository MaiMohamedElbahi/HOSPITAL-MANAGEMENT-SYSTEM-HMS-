using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Data;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Interfaces;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Implementations
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly AppDbContext _context;
        public IGenericRepo<Department> Departments { get; set; }
        public IGenericRepo<Doctor> Doctors { get; set; }
        public IGenericRepo<Patient> Patients { get; set; }
        public IGenericRepo<MedicalRecord> MedicalRecords { get; set; }
        public IGenericRepo<Appointment> Appointments { get; set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Departments = new GenericRepo<Department>(_context);
            Doctors = new GenericRepo<Doctor>(_context);
            Patients = new GenericRepo<Patient>(_context);
            MedicalRecords = new GenericRepo<MedicalRecord>(_context);
            Appointments = new GenericRepo<Appointment>(_context);

        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
