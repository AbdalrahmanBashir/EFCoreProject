using EFCoreProject.Domain.DTOs.DoctorDTOs;
using EFCoreProject.Domain.Contracts;
using EFCoreProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using EFCoreProject.Domain.DTOs.PrescriptionsDTOs;
using EFCoreProject.Domain.DTOs.PatientDTOs;

namespace EFCoreProject.DAL.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async IAsyncEnumerable<DoctorWithPatientCount> GetAllDoctorsWithPatientCountAsync()
        {
            var result = _context.Doctors
                .Select(d => new DoctorWithPatientCount
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Address = d.Address,
                    ExperienceYears = d.ExperienceYears,
                    Speciality = d.Speciality,
                    PatientCount = d.Patients.Count(),
                });

             await  foreach (var doctor in result.AsAsyncEnumerable()){

                yield return doctor;
             }

        }



        public async Task<DoctorById> GetDoctorByIdAsync(string? personSsn)
        {
            var result = await _context.Doctors
                .Where(x => x.PersonSsn == personSsn)
                 .Select(d => new DoctorById
                 {
                     FirstName = d.FirstName,
                     LastName = d.LastName,
                     Address = d.Address,
                     ExperienceYears = d.ExperienceYears,
                     Speciality = d.Speciality,
                 })
                .SingleOrDefaultAsync();

            return result;
        }

        public async IAsyncEnumerable<DoctorWithPrescriptions> GetDoctorsWithPrescriptionsAsync()
        {
 
            var result = _context.Doctors
               .Select(d => new DoctorWithPrescriptions
               {
                   FirstName = d.FirstName,
                   LastName = d.LastName,
                   Address = d.Address,
                   ExperienceYears = d.ExperienceYears,
                   Speciality = d.Speciality,
                   PrescriptionsDto = d.Prescriptions
                       .ToList()
                       .Select(p => new PrescriptionDto
                       {
                           PatientSsn = p.PatientSsn,
                           DoctorSsn = p.DoctorSsn,
                           DrugTradeName = p.DrugTradeName,
                           LatestDate = p.LatestDate,
                           Quantity = p.Quantity
                       })
                       .ToList()
               });
            await foreach(var doctor in result.AsAsyncEnumerable())
            {
                yield return doctor;
            }
        }


        public async IAsyncEnumerable<DoctorsSpeciality> GetDoctorsBySpecialityAsync(string speciality)
        {
            var result = _context.Doctors.Where(d => d.Speciality == speciality)
                .Select(d => new DoctorsSpeciality
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Speciality = d.Speciality
                });

            await foreach (var doctor in result.AsAsyncEnumerable()) { yield return doctor; }

        }

        public async IAsyncEnumerable<DoctorsExperience> GetDoctorsWithExperienceAsync(int experienceYears)
        {
            var result = _context.Doctors.Where(d => d.ExperienceYears >= experienceYears)
                .OrderBy(d => d.ExperienceYears)
                .Select(d => new DoctorsExperience
                {
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Speciality = d.Speciality,
                    ExperienceYears = d.ExperienceYears

                });
            await foreach(var doctor in result.AsAsyncEnumerable())
            {
                yield return doctor;
            }  
        }


        
        public async Task<DoctorDto> GetDoctorWithPatientsAndPrescriptionsAsync(string personSsn)
        {
            var startTime = DateTime.Now;
            Console.WriteLine($"Query started at: {startTime}");
            var doctor = await _context.Doctors.Where(d => d.PersonSsn == personSsn)
                .Include(d => d.Patients)
                .ThenInclude(p => p.Prescriptions)
                .Select(d => new DoctorDto
                {
                    DotorId = d.PersonSsn,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    PatientDto = d.Patients
                    .ToList()
                    .Select(p => new PatientDto
                    {
                        PersonSsn = p.PersonSsn,
                        FirstName = p.FirstName,
                        LastName= p.LastName,
                        DoctorSsn = p.DoctorSsn,
                        PrescriptionsDto = p.Prescriptions
                        .ToList()
                        .OrderByDescending(p => p.LatestDate)
                        .Select(pre => new PrescriptionDto
                        {
                            PatientSsn = pre.PatientSsn,
                            DoctorSsn = pre.DoctorSsn,
                            DrugTradeName = pre.DrugTradeName,
                            LatestDate = pre.LatestDate,
                            Quantity = pre.Quantity
                        }).ToList()

                    }).ToList(),

                })
                .SingleOrDefaultAsync();

            var endTime = DateTime.Now;
            Console.WriteLine($"Query finished at: {endTime}. Elapsed time: {endTime - startTime}");
            if (doctor == null) return null;
            return doctor;

        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
           
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


        Task<int> IDoctorRepository.AddDoctorAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        Task<int> IDoctorRepository.DeleteDoctorAsync(string personSsn)
        {
            throw new NotImplementedException();
        }
    }
}
