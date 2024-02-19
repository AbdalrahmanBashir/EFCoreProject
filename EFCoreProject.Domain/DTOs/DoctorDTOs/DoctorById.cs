using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.Domain.DTOs.DoctorDTOs
{
    public class DoctorById
    {
        public string? DoctorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Speciality { get; set; }
        public int? ExperienceYears { get; set; }
    }
}
