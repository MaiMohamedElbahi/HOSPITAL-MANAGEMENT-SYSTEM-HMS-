using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DoctorDTOs
{
    public class PartiallyUpdateDoctorDTO
    {
        public int? DoctorId { get; set; }
        public string? FullName { get; set; }
        public string? Specialization { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public decimal? Salary { get; set; }
        public int? DepartmentId { get; set; }
    }
}
