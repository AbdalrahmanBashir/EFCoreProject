using EFCoreProject.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaceuticalCompanyController : ControllerBase
    {
        private readonly IPharmaceuticalCompanyRepository _PharmaceuticalCompanyRepository;

        public PharmaceuticalCompanyController(IPharmaceuticalCompanyRepository pharmaceuticalCompanyRepository)
        {
            _PharmaceuticalCompanyRepository = pharmaceuticalCompanyRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var result =  _PharmaceuticalCompanyRepository.GetAllAsync();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Contracts/{id}")]
        public async Task<ActionResult> PharmaceuticalCompanyContracts(string id)
        {
            try
            {
                var result = await _PharmaceuticalCompanyRepository
                    .PharmaceuticalCompanyContractsAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Drugs/{id}")]
        public async Task<ActionResult> PharmaceuticalCompanyDrugs(string id)
        {
            try
            {
                var result = await _PharmaceuticalCompanyRepository
                    .PharmaceuticalCompanyDrugsAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
