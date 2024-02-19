using EFCoreProject.Domain.DTOs.PrescriptionsDTOs;
using EFCoreProject.Domain.Models;

namespace EFCoreProject.Domain.DTOs.DoctorDTOs
{
    public class DoctorWithPrescriptions
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Speciality { get; set; }
        public int? ExperienceYears { get; set; }
        public ICollection<PrescriptionDto>? PrescriptionsDto { get; set; }
       // public ICollection<Prescription>? Prescriptions { get; set; }
    }
}
