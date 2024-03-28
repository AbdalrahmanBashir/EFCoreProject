
using EFCoreProject.Domain.DTOs.PatientDTOs;

namespace EFCoreProject.Domain.DTOs.DoctorDTOs
{
    public class DoctorDto
    {
        public string? DotorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Speciality { get; set; }
        public int ExperienceYears { get; set; }
        public virtual IEnumerable<PatientDto> PatientDto { get; set; }
       
    }
}
