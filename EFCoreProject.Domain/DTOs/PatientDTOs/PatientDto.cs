using EFCoreProject.Domain.DTOs.PrescriptionsDTOs;

namespace EFCoreProject.Domain.DTOs.PatientDTOs
{
    public class PatientDto
    {
        public string PersonSsn { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public virtual IEnumerable<PrescriptionDto>? PrescriptionsDto { get; set; }
    }
}
