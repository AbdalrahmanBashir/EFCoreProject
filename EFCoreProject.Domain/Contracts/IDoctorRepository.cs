using EFCoreProject.Domain.DTOs.DoctorDTOs;
using EFCoreProject.Domain.Models;

namespace EFCoreProject.Domain.Contracts
{
    public interface IDoctorRepository
    {
       
        IAsyncEnumerable<DoctorWithPatientCount> GetAllDoctorsWithPatientCountAsync();
        Task<DoctorDto> GetDoctorByIdAsync(string? personSsn);
        IAsyncEnumerable<DoctorDto> GetDoctorsBySpecialityAsync(string speciality);
        IAsyncEnumerable<DoctorDto> GetDoctorsWithExperienceAsync(int experienceYears);
        IAsyncEnumerable<DoctorWithPrescriptions> GetDoctorsWithPrescriptionsAsync();
        Task UpdateDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(string personSsn);
        Task AddDoctorAsync(Doctor doctor);
    }
}