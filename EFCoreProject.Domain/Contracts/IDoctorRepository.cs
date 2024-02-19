using EFCoreProject.Domain.DTOs.DoctorDTOs;
using EFCoreProject.Domain.Models;

namespace EFCoreProject.Domain.Contracts
{
    public interface IDoctorRepository
    {
        IAsyncEnumerable<DoctorWithPatientCount> GetAllDoctorsWithPatientCountAsync();
        Task<DoctorById> GetDoctorByIdAsync(string personSsn);
        IAsyncEnumerable<DoctorWithPrescriptions> GetDoctorsWithPrescriptionsAsync();
        IAsyncEnumerable<DoctorsSpeciality> GetDoctorsBySpecialityAsync(string speciality);
        IAsyncEnumerable<DoctorsExperience> GetDoctorsWithExperienceAsync(int experienceYears);
        Task<DoctorDto> GetDoctorWithPatientsAndPrescriptionsAsync(string personSsn);

        Task<int> AddDoctorAsync(Doctor doctor);

        Task UpdateDoctorAsync(Doctor doctor);

        Task<int> DeleteDoctorAsync(string personSsn);
    }
}
