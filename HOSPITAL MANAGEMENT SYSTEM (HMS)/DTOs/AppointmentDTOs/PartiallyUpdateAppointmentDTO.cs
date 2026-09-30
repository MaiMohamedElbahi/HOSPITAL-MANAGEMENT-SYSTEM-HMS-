using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.AppointmentDTOs
{
    public class PartiallyUpdateAppointmentDTO
    {
        public int? AppointmentId { get; set; }
        public DateOnly? AppointmentDate { get; set; }
        public string? Status { get; set; }

        public int? DoctorId { get; set; }

        public int? PatientId { get; set; }

        public int? MedicalRecordId { get; set; }
    }
}
