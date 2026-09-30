using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required][MaxLength(150)]
        public string FullName { get; set; }
        [Required][MaxLength(150)]
        public string Specialization { get; set; }
        [Required][EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        [MaxLength(25)]
        public string Phone { get; set; }
        [Required][Range(0, int.MaxValue)]
        public decimal Salary { get; set; }


        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
