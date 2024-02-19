using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.DAL.DTOs.DoctorDTOs
{
    public class DoctorWithPatientCount
    {
        public string? PersonSsn { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Speciality { get; set; }
        public int ExperienceYears { get; set; }
        public int PatientCount { get; set; }
    }
}
