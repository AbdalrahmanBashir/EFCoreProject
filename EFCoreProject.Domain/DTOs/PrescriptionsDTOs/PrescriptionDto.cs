using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.Domain.DTOs.PrescriptionsDTOs
{
    public class PrescriptionDto
    {
        public string DoctorSsn { get; set; } = null!;

        public string PatientSsn { get; set; } = null!;

        public string DrugTradeName { get; set; } = null!;

        public DateOnly LatestDate { get; set; }

        public int Quantity { get; set; }
    }
}
