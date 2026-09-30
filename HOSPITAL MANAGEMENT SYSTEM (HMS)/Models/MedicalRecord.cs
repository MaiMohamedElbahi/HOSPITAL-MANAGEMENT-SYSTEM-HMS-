using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models
{
    public class MedicalRecord
    {
        [Key]
        public int MedicalRecordId { get; set; }
        [Required][MaxLength(500)]
        public string Diagnosis {  get; set; }
        [Required][MaxLength(1000)]
        public string Prescription {  get; set; }
        [MaxLength(1000)]
        public string? Notes {  get; set; }

        public int? AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
