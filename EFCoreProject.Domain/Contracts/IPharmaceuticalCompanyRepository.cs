using EFCoreProject.Domain.DTOs.PharmaceuticalCompanyDTOS;
using EFCoreProject.Domain.Models;

namespace EFCoreProject.Domain.Contracts
{
    public interface IPharmaceuticalCompanyRepository
    {
        IAsyncEnumerable<PharmaceuticalCompany> GetAllAsync();
        Task<PharmaceuticalCompany> PharmaceuticalCompanyContractsAsync(string id);
        Task<PharmaceuticalCompanyDrugsDto> PharmaceuticalCompanyDrugsAsync(string id);

        Task AddAsync(PharmaceuticalCompany pharmaceuticalCompany);
        Task UpdateAsync(PharmaceuticalCompany pharmaceuticalCompany);
        Task DeleteAsync(string id);
    }
}
