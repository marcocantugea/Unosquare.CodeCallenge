using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseServices.Services;
using WarehouseModels.Models;
using WarehouseServices.Contractor;
using System.Text;
using System.Text.Json;

namespace WarehouseRESTfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private CompaniesServices _companyService;

        public CompaniesController(IWarehouseService<CompaniesServices> companyservice)
        {
            _companyService = (CompaniesServices)companyservice;
        }

        [HttpGet]
        public IActionResult getAllCompanies()
        {
            return  Ok(_companyService.GetAllCompanies());
        }

        [HttpGet("{idEncoded}")]
        public IActionResult getCompany([FromRoute]string idEncoded)
        {
            try
            {
                if (String.IsNullOrEmpty(idEncoded)) return BadRequest();
                var valueBytes = System.Convert.FromBase64String(idEncoded);
                int idCompany = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                return Ok(_companyService.GetCompany(idCompany));
            }
            catch (Exception)
            { 
                return Problem("invalid id",null,500);
            }
        }

    }
}
