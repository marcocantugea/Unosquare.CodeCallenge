using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseServices.Services;
using WarehouseModels.Models;
using WarehouseServices.Contractor;

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
    }
}
