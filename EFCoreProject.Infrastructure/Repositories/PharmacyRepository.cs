using EFCoreProject.Domain.Contracts;
using EFCoreProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreProject.Infrastructure.Repositories
{
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly PharmacyPrescriptionManagementSystemContext _applicationDbContext;
        public PharmacyRepository(PharmacyPrescriptionManagementSystemContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task AddAsync(Pharmacy pharmacy)
        {
            await _applicationDbContext.Pharmacies.AddAsync(pharmacy);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(string pharmacyId)
        {
            var pharmacy = await _applicationDbContext.Pharmacies.FindAsync(pharmacyId);

            if (pharmacy == null)
            {
                return;
            }

            _applicationDbContext.Pharmacies.Remove(pharmacy);

            await _applicationDbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Pharmacy>> GetAllAsync()
        {
            return await _applicationDbContext.Pharmacies.ToListAsync();
        }

        

        public async Task<Pharmacy> GetByIdAsync(string pharmacyId)
        {
            var result = _applicationDbContext.Pharmacies
                .Where(phar => phar.PharmacyName == pharmacyId)
                .FirstOrDefault();

            return result;
        }

        public async Task<IEnumerable<Contract>> GetContractsAsync(string pharmacyId)
        {
            return await _applicationDbContext.Contracts
                .Where(contract => contract.PharmacyName == pharmacyId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pharmacy>> GetPharmaciesByAddressAsync(string address)
        {
            return await _applicationDbContext.Pharmacies
                .Where(pharmacy => pharmacy.Address.ToLower().Contains(address.ToLower()))
                .ToListAsync();
        }

        public async Task<IEnumerable<Pharmacy>> GetPharmaciesByConditionAsync(string condition)
        {
            return await _applicationDbContext.Pharmacies
                .Where(pharmacy => pharmacy.PharmacyName.ToLower().Contains(condition.ToLower()))
                .ToListAsync();
        }

        public async Task<IEnumerable<Sale>> GetSalesAsync(string pharmacyId)
        {
            return await _applicationDbContext.Sales
                .Where(sale => sale.PharmacyName == pharmacyId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pharmacy>> GetTopPharmaciesBySalesAsync(int topCount)
        {
           /* return await _applicationDbContext.Pharmacies
                .OrderByDescending(pharmacy => pharmacy.Sales.Count)
                .Take(topCount)
                .ToListAsync();*/

            return await _applicationDbContext.Pharmacies
                .OrderByDescending(pharmacy => pharmacy.Sales!.Sum(sale => sale.Price))
                .Take(topCount)
                .ToListAsync();
        }

        public async Task<Decimal> GetTotalSalesByPharmacyAsync(string pharmacyId)
        {
            return await _applicationDbContext.Sales
                .Where(sale => sale.PharmacyName == pharmacyId)
                .SumAsync(sale => sale.Price);
        }

        public Task<IEnumerable<Pharmacy>> SearchPharmaciesAsync(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Pharmacy pharmacy)
        {
            var pharmacyFromDb = await _applicationDbContext.Pharmacies
                .FirstOrDefaultAsync(p => p.PharmacyName == pharmacy.PharmacyName);

            if (pharmacyFromDb == null)
            {
                throw new Exception($"Pharmacy with id {pharmacy.PharmacyName} not found");
            }

            _applicationDbContext.Pharmacies.Update(pharmacy);

            await _applicationDbContext.SaveChangesAsync();
        }

    }
}
