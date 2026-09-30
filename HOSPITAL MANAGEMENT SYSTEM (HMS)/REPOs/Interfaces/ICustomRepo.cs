using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.REPOs.Interfaces
{
    public interface ICustomRepo<T> where T : class
    {
        List<Doctor> DoctorsDetais();
        List<Patient> PatientHistory();
    }
}
