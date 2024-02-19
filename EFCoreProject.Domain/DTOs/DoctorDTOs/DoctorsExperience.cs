using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.Domain.DTOs.DoctorDTOs
{
    public class DoctorsExperience
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Speciality { get; set; }
        public int ExperienceYears { get; set; }
    }
}
