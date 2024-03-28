using EFCoreProject.Domain.Contracts;
using EFCoreProject.Domain.DTOs.DoctorDTOs;
using EFCoreProject.Domain.DTOs.PatientDTOs;
using EFCoreProject.Domain.DTOs.PrescriptionsDTOs;
using EFCoreProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProject.Infrastructure.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly PharmacyPrescriptionManagementSystemContext _context;
        public DoctorRepository(PharmacyPrescriptionManagementSystemContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Gets all doctors with their patient counts.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="DoctorWithPatientCount"/> objects.
        /// </returns>
        public async IAsyncEnumerable<DoctorWithPatientCount> GetAllDoctorsWithPatientCountAsync()
        {
            // Query all doctors with their patient count.
            var result = _context.Doctors
                .AsNoTracking()
                .Select(d => new DoctorWithPatientCount
                {
                    DotorId = d.PersonSsn,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Address = d.Address,
                    ExperienceYears = d.ExperienceYears,
                    Speciality = d.Speciality,
                    PatientCount = d.Patients!.Count()
                })
                .OrderBy(d => d.ExperienceYears);

            // Loop through the doctors and yield them.
            await foreach (var doctor in result.AsAsyncEnumerable())
            {
                if (doctor == null)
                {
                    throw new InvalidOperationException(
                        "The returned doctor is null. This is likely a bug. Please report it.");
                }

                yield return doctor;
            }
        }





        /// <summary>
        /// Gets a doctor by their person SSN.
        /// </summary>
        /// <returns>
        /// A <see cref="Doctor"/> object if found, otherwise null.
        /// </returns>
        public async Task<DoctorDto> GetDoctorByIdAsync(string? personSsn)
        {
            // Query a single doctor by their person SSN.
            // Query a single doctor with their patients and prescriptions.
            var doctor = await _context.Doctors
                .Where(d => d.PersonSsn == personSsn)
                .Include(d => d.Patients!)
                .ThenInclude(p => p.Prescriptions!)
                .Select(d => new DoctorDto
                {
                    DotorId = d.PersonSsn,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Address = d.Address,
                    Speciality = d.Speciality,
                    ExperienceYears = d.ExperienceYears,
                    PatientDto = d.Patients!
                    .Select(p => new PatientDto
                    {
                        PersonSsn = p.PersonSsn,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        PrescriptionsDto = p.Prescriptions!
                        .Select(pre => new PrescriptionDto
                        {
                            DrugTradeName = pre.DrugTradeName,
                            LatestDate = pre.LatestDate,
                            Quantity = pre.Quantity
                        })

                    })

                })
                .FirstOrDefaultAsync();

            return doctor!;
        }


        /// <summary>
        /// Gets all doctors with their prescriptions.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="DoctorWithPrescriptions"/> objects.
        /// </returns>
        public async IAsyncEnumerable<DoctorWithPrescriptions> GetDoctorsWithPrescriptionsAsync()
        {
            // Query all doctors with their prescriptions.
            var result = _context.Doctors
                .AsNoTracking()
                .Include(d => d.Prescriptions!)
                .Select(d => new DoctorWithPrescriptions
                {
                    DotorId = d.PersonSsn,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Address = d.Address,
                    Speciality = d.Speciality,
                    ExperienceYears = d.ExperienceYears,
                    PrescriptionsDto = d.Prescriptions!
                        .Select(p => new PrescriptionDto
                        {

                            DrugTradeName = p.DrugTradeName,
                            LatestDate = p.LatestDate,
                            Quantity = p.Quantity
                        })

                });

            // Loop through the doctors and yield them.
            await foreach (var doctor in result.AsAsyncEnumerable())
            {
                yield return doctor;
            }
        }


        /// <summary>
        /// Gets all doctors with a specific speciality.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="DoctorDto"/> objects representing the doctors.
        /// </returns>
        public async IAsyncEnumerable<DoctorDto> GetDoctorsBySpecialityAsync(string speciality)
        {
            // Query all doctors with the specified speciality.
            var result = _context.Doctors
                .Where(d => d.Speciality == speciality)
                .Include(d => d.Patients!)
                .ThenInclude(p => p.Prescriptions!)
                .Select(d => new DoctorDto
                {
                    DotorId = d.PersonSsn,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Speciality = d.Speciality,
                    ExperienceYears = d.ExperienceYears,
                    PatientDto = d.Patients!
                    .Select(p => new PatientDto
                    {
                        PersonSsn = p.PersonSsn,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        PrescriptionsDto = p.Prescriptions!
                        .Select(pre => new PrescriptionDto
                        {
                            DrugTradeName = pre.DrugTradeName,
                            LatestDate = pre.LatestDate,
                            Quantity = pre.Quantity
                        })
                    })
                });

            // Loop through the doctors and yield them.
            await foreach (var doctor in result.AsAsyncEnumerable())
            {
                yield return doctor;
            }
        }

        /// <summary>
        /// Gets all doctors with a minimum of experience years.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="DoctorsExperience"/> objects representing the doctors.
        /// </returns>
        public async IAsyncEnumerable<DoctorDto> GetDoctorsWithExperienceAsync(int experienceYears)
        {
            // Query all doctors with a minimum of experience years.
            var result = _context.Doctors
                .Where(d => d.ExperienceYears >= experienceYears)
                .Include(d => d.Patients!)
                .OrderBy(d => d.ExperienceYears)
                .Select(d => new DoctorDto
                {
                    DotorId = d.PersonSsn,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Speciality = d.Speciality,
                    ExperienceYears = d.ExperienceYears,
                    PatientDto = d.Patients!
                    .Select(p => new PatientDto
                    {
                        PersonSsn = p.PersonSsn,
                        FirstName = p.FirstName,
                        LastName = p.LastName,
                        PrescriptionsDto = p.Prescriptions!
                        .Select(pre => new PrescriptionDto
                        {
                            DrugTradeName = pre.DrugTradeName,
                            LatestDate = pre.LatestDate,
                            Quantity = pre.Quantity
                        })
                    })

                });

            // Loop through the doctors and yield them.
            await foreach (var doctor in result.AsAsyncEnumerable())
            {
                yield return doctor;
            }
        }


        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            if (doctor == null) return;
            _context.Update(doctor);
            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }


        public async Task AddDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(string personSsn)
        {
            var doctor = await _context.Doctors.FindAsync(personSsn);
            _context.Doctors.Remove(doctor!);
            await _context.SaveChangesAsync();
        }
    }
}
