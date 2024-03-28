using EFCoreProject.Domain.Contracts;
using EFCoreProject.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyRepository _pharmacyRepository;

        public PharmacyController(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        // GET: api/Pharmacies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pharmacy>>> GetPharmacies()
        {
            var pharmacies = await _pharmacyRepository.GetAllAsync();
            return Ok(pharmacies);
        }

        // GET: api/Pharmacies/5
        [HttpGet("{pharmacyId}")]
        public async Task<ActionResult<Pharmacy>> GetPharmacy(string pharmacyId)
        {
            var pharmacy = await _pharmacyRepository.GetByIdAsync(pharmacyId);

            if (pharmacy == null)
            {
                return NotFound();
            }

            return Ok(pharmacy);
        }

        // POST: api/Pharmacies
        [HttpPost]
        public async Task<ActionResult<Pharmacy>> AddPharmacy(Pharmacy pharmacy)
        {
            await _pharmacyRepository.AddAsync(pharmacy);
            return CreatedAtRoute("GetPharmacy", new { pharmacyId = pharmacy.PharmacyName }, pharmacy);
        }

        // PUT: api/Pharmacies/5
        [HttpPut("{pharmacyId}")]
        public async Task<IActionResult> UpdatePharmacy(string pharmacyId, Pharmacy pharmacy)
        {
            if (pharmacyId != pharmacy.PharmacyName)
            {
                return BadRequest();
            }

            await _pharmacyRepository.UpdateAsync(pharmacy);
            return NoContent();
        }

        // DELETE: api/Pharmacies/5
        [HttpDelete("{pharmacyId}")]
        public async Task<ActionResult> DeletePharmacy(string pharmacyId)
        {
            await _pharmacyRepository.DeleteAsync(pharmacyId);
            return NoContent();
        }

        // GET: api/Pharmacies/search?searchTerm={term}
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Pharmacy>>> SearchPharmacies(string searchTerm)
        {
            var pharmacies = await _pharmacyRepository.SearchPharmaciesAsync(searchTerm);
            return Ok(pharmacies);
        }

        // GET: api/Pharmacies/1/contracts
        [HttpGet("{pharmacyId}/contracts")]
        public async Task<ActionResult<IEnumerable<Contract>>> GetContracts(string pharmacyId)
        {
            var contracts = await _pharmacyRepository.GetContractsAsync(pharmacyId);
            return Ok(contracts);
        }

        // GET: api/Pharmacies/searchByAddress?address={term}
        [HttpGet("searchByAddress")]
        public async Task<ActionResult<IEnumerable<Pharmacy>>> GetPharmaciesByAddress(string address)
        {
            var pharmacies = await _pharmacyRepository.GetPharmaciesByAddressAsync(address);
            return Ok(pharmacies);
        }

        // GET: api/Pharmacies/searchByName?condition={term}
        [HttpGet("searchByName")]
        public async Task<ActionResult<IEnumerable<Pharmacy>>> GetPharmaciesByCondition(string condition)
        {
            var pharmacies = await _pharmacyRepository.GetPharmaciesByConditionAsync(condition);
            return Ok(pharmacies);
        }

        // GET: api/Pharmacies/1/sales
        [HttpGet("{pharmacyId}/sales")]
        public async Task<ActionResult<IEnumerable<Sale>>> GetSales(string pharmacyId)
        {
            var sales = await _pharmacyRepository.GetSalesAsync(pharmacyId);
            return Ok(sales);
        }

        // GET: api/Pharmacies/top/{topCount}
        [HttpGet("top/{topCount}")]
        public async Task<ActionResult<IEnumerable<Pharmacy>>> GetTopPharmaciesBySales(int topCount)
        {
            var pharmacies = await _pharmacyRepository.GetTopPharmaciesBySalesAsync(topCount);
            return Ok(pharmacies);
        }

        // GET: api/Pharmacies/1/totalSales
        [HttpGet("{pharmacyId}/totalSales")]
        public async Task<ActionResult<Decimal>> GetTotalSalesByPharmacy(string pharmacyId)
        {
            var totalSales = await _pharmacyRepository.GetTotalSalesByPharmacyAsync(pharmacyId);
            return Ok(totalSales);
        }
    }

}