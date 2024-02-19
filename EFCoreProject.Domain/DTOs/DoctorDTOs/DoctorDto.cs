using EFCoreProject.Domain.DTOs.PatientDTOs;
using EFCoreProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.Domain.DTOs.DoctorDTOs
{
    public class DoctorDto
    {
        public string? DotorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<PatientDto> PatientDto { get; set; } = new List<PatientDto>();
       
    }
}
