using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.MedicalRecordDTOs
{
    public class PartiallyUpdateMedicalRecordDTO
    {
        public int? MedicalRecordId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Prescription { get; set; }
        public string? Notes { get; set; }
        public int? AppointmentId { get; set; }
    }
}
