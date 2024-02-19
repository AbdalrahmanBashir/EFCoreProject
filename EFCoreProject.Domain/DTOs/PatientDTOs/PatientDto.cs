using EFCoreProject.Domain.DTOs.PrescriptionsDTOs;
using EFCoreProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.Domain.DTOs.PatientDTOs
{
    public class PatientDto
    {
        public string PersonSsn { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? DoctorSsn { get; set; }

        public virtual ICollection<PrescriptionDto> PrescriptionsDto { get; set; } = new List<PrescriptionDto>();
    }
}
