using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseServices.Services;
using WarehouseModels.Models;
using WarehouseServices.Contractor;
using System.Text;

namespace WarehouseRESTfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class companies : ControllerBase
    {
        private CompaniesServices companyService;

        public companies(IWarehouseService companyservice)
        {
            companyService = (CompaniesServices)companyservice;
        }


        [HttpGet]
        public IEnumerable<Company> getAllCompanies()
        {
            return companyService.getAllCompanies();
        }

        [HttpGet("{id}")]
        public IActionResult getCompany([FromRoute]string id)
        {
            try
            {
                if (id == null) return this.BadRequest();
                var valueBytes = System.Convert.FromBase64String(id);
                int idCompany = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                return this.Ok(companyService.getCompany(idCompany));
            }
            catch (Exception)
            {

                return this.Problem("invalid id",null,500);
            }
        }

    }
}
