using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.AppointmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DepartmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DoctorDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.MedicalRecordDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.PatientDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department,CreateUpdateDepartmentDTO>().ReverseMap();
            CreateMap<Department,PartiallyUpdateDepartmentDTO>().ReverseMap();

            CreateMap<MedicalRecord, CreateUpdateMedicalRecordDTO>().ReverseMap();
            CreateMap<MedicalRecord, PartiallyUpdateMedicalRecordDTO>().ReverseMap();

            CreateMap<Doctor, CreateUpdateDoctorDTO>().ReverseMap();
            CreateMap<Doctor, PartiallyUpdateDoctorDTO>().ReverseMap();

            CreateMap<Patient, CreateUpdatePatientDTO>().ReverseMap();
            CreateMap<Patient, PartiallyUpdatePatientDTO>().ReverseMap();

            CreateMap<Appointment, CreateUpdateAppointmentDTO>().ReverseMap();
            CreateMap<Appointment, PartiallyUpdateAppointmentDTO>().ReverseMap();
        }
    }
}
