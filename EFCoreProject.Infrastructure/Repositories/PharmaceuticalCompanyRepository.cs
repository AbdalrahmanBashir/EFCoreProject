using EFCoreProject.Domain.Contracts;
using EFCoreProject.Domain.DTOs.DrugDTOs;
using EFCoreProject.Domain.DTOs.PharmaceuticalCompanyDTOS;
using EFCoreProject.Domain.Models;

using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace EFCoreProject.Infrastructure.Repositories
{
    public class PharmaceuticalCompanyRepository : IPharmaceuticalCompanyRepository
    {
        private readonly PharmacyPrescriptionManagementSystemContext _context;
        public PharmaceuticalCompanyRepository(PharmacyPrescriptionManagementSystemContext context)
        {
            _context = context;
        }
        public async Task AddAsync(PharmaceuticalCompany pharmaceuticalCompany)
        {
            _context.PharmaceuticalCompanies.Add(pharmaceuticalCompany);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
         var pharmaceuticalCompany = await _context.PharmaceuticalCompanies.FindAsync(id);
            _context.PharmaceuticalCompanies.Remove(pharmaceuticalCompany!);
         await _context.SaveChangesAsync();

        }

        public async IAsyncEnumerable<PharmaceuticalCompany> GetAllAsync()
        {
            var result = _context.PharmaceuticalCompanies
                .Select(p => new PharmaceuticalCompany
                {
                    PharmaceuticalCompanyName = p.PharmaceuticalCompanyName,
                    PhoneNumber = p.PhoneNumber,
                });

            await foreach (var pharmaceuticalCompanyName in result.AsAsyncEnumerable())
            {
                yield return pharmaceuticalCompanyName;
            };
        }

        public async Task<PharmaceuticalCompany> PharmaceuticalCompanyContractsAsync(string PharmaceuticalCompanyName)
        {
            var result = await _context.PharmaceuticalCompanies
                .Where(p => p.PharmaceuticalCompanyName == PharmaceuticalCompanyName)
                .Include(x => x.Contracts)
                .Select(x => new PharmaceuticalCompany
                {
                    PharmaceuticalCompanyName = x.PharmaceuticalCompanyName,
                    PhoneNumber = x.PhoneNumber,
                    Contracts = x.Contracts!
                    .Select(c => new Contract
                    {
                        StartDate = c.StartDate,
                        EndDate = c.EndDate,
                        Text = c.Text,
                        PharmacyName = c.PharmacyName,
                        PharmaceuticalCompanyName = c.PharmaceuticalCompanyName,
                        supervisor = c.supervisor

                    })

                })
                .FirstOrDefaultAsync();

            return result!;
        }

        public async Task<PharmaceuticalCompanyDrugsDto> PharmaceuticalCompanyDrugsAsync(string PharmaceuticalCompanyName)
        {
            var result = await _context.PharmaceuticalCompanies
                .Where(p => p.PharmaceuticalCompanyName == PharmaceuticalCompanyName)
                .Include(x => x.Drugs)
                .Select(x => new PharmaceuticalCompanyDrugsDto
                {
                    PharmaceuticalCompanyName = x.PharmaceuticalCompanyName,
                    PhoneNumber = x.PhoneNumber,
                    DrugsDto = x.Drugs!
                    .Select(c => new DrugDto
                    {
                        DrugTradeName = c.DrugTradeName,
                        Formula = c.Formula,
                        PharmaceuticalCompanyName = c.PharmaceuticalCompanyName
                    })
                    
                })
                .FirstOrDefaultAsync();

            return result!;
        }

        public async Task UpdateAsync(PharmaceuticalCompany pharmaceuticalCompany)
        {

            if (pharmaceuticalCompany == null) return;
            _context.Update(pharmaceuticalCompany);
            _context.Entry(pharmaceuticalCompany).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }
    }
}
