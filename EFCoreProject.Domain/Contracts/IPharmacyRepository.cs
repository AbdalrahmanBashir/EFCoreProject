using EFCoreProject.Domain.Models;

namespace EFCoreProject.Domain.Contracts
{
    public interface IPharmacyRepository
    {
        Task<IEnumerable<Pharmacy>> GetAllAsync();
        Task<Pharmacy> GetByIdAsync(string pharmacyId);
        Task AddAsync(Pharmacy pharmacy);
        Task UpdateAsync(Pharmacy pharmacy);
        Task DeleteAsync(string pharmacyId);

        Task<IEnumerable<Contract>> GetContractsAsync(string pharmacyId);
        //Task<IEnumerable<Sale>> GetSalesAsync(string pharmacyId);
        Task<IEnumerable<Pharmacy>> GetPharmaciesByConditionAsync(string condition);
        Task<IEnumerable<Pharmacy>> SearchPharmaciesAsync(string searchTerm);
       Task<IEnumerable<Pharmacy>> GetTopPharmaciesBySalesAsync(int topCount);
       Task<Decimal> GetTotalSalesByPharmacyAsync(string pharmacyId);
        Task<IEnumerable<Pharmacy>> GetPharmaciesByAddressAsync(string address);
        Task<IEnumerable<Sale>> GetSalesAsync(string pharmacyId);
    }
}
