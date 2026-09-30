using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        IGenericRepo<Department> Departments { get; }
        IGenericRepo<Doctor> Doctors { get; }
        IGenericRepo<Patient> Patients { get;  }
        IGenericRepo<MedicalRecord> MedicalRecords { get; }
        IGenericRepo<Appointment> Appointments { get;  }

        void Save();
    }
}
