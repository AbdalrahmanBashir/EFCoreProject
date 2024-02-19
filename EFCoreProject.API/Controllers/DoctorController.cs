using EFCoreProject.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EFCoreProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet("AllWithPatientCoun")]
        public ActionResult GetAllDoctorsAsync()
        {
            try
            {
                var doctors = _doctorRepository.GetAllDoctorsWithPatientCountAsync();
                return Ok(doctors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to retrieve doctors");
            }
        }

        [HttpGet("ById/{doctorId}")]
        public async Task<ActionResult> GetDoctorByIdAsync(string doctorId)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(doctorId);
            return Ok(doctor);
        }

        [HttpGet("PrescriptionsDetails")]
        public  ActionResult GetDoctorsWithPrescriptionsAsync()
        {
            try
            {
                var doctorsWithPrescriptions = _doctorRepository.GetDoctorsWithPrescriptionsAsync();
                return Ok(doctorsWithPrescriptions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to retrieve doctors with prescriptions");
            }
        }

        [HttpGet("BySpeciality/{speciality}")]
        public ActionResult GetDoctorsBySpecialityAsync(string speciality)
        {
            try
            {
                var doctorsBySpeciality = _doctorRepository.GetDoctorsBySpecialityAsync(speciality);
                return Ok(doctorsBySpeciality);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to retrieve doctors by speciality");
            }
        }
        

         [HttpGet("ByExperience/{experience}")]
        public ActionResult GetDoctorsbyExperienceAsync(int experience)
        {
            try
            {
                var doctorsByExperience = _doctorRepository.GetDoctorsWithExperienceAsync(experience);
                return Ok(doctorsByExperience);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to retrieve doctors by speciality");
            }
        }

        [HttpGet("Details/{Id}")]
        public async Task<ActionResult> GetDoctorsWithPatientsAndPrescriptionsAsync(string Id)
        {
            try
            {
                var reult =  await _doctorRepository.GetDoctorWithPatientsAndPrescriptionsAsync(Id);
                return Ok(reult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Failed to retrieve doctors with prescriptions");
            }
        }
    }
}
