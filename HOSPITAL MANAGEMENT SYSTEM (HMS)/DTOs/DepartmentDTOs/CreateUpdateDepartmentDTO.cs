using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DepartmentDTOs
{
    public class CreateUpdateDepartmentDTO
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string? Location { get; set; }
    }
}
