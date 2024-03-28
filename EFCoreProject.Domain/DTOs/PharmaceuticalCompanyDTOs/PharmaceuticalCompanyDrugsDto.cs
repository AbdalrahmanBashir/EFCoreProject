using EFCoreProject.Domain.DTOs.DrugDTOs;

namespace EFCoreProject.Domain.DTOs.PharmaceuticalCompanyDTOS
{
    public class PharmaceuticalCompanyDrugsDto
    {
        public string PharmaceuticalCompanyName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public virtual IEnumerable<DrugDto> DrugsDto { get; set; }
    }
}
