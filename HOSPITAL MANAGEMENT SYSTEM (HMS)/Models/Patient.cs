using System.ComponentModel.DataAnnotations;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(20)]
        public string Gender { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [Phone]
        [MaxLength(25)]
        public string Phone { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
