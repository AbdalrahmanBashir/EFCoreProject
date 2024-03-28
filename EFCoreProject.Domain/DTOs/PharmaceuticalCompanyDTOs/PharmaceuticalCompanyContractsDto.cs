using EFCoreProject.Domain.DTOs.ContractDTOs;

namespace EFCoreProject.Domain.DTOs.PharmaceuticalCompanyDTOS
{
    public class PharmaceuticalCompanyContractsDto
    {
        public string PharmaceuticalCompanyName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public virtual ICollection<ContractDto> ContractsDto { get; set; } = new List<ContractDto>();

    }
}
