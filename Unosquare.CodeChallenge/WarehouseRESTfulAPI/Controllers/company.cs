using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseServices.Services;
using WarehouseModels.Models;
using WarehouseServices.Contractor;
using System.Text;
using WarehouseModels.Interfaces;
using WarehouseModels.Validations;
using System.Text.Json;

namespace WarehouseRESTfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class company : ControllerBase
    {
        private CompaniesServices companyService;

        public company(IWarehouseService<CompaniesServices> companyservice)
        {
            companyService = (CompaniesServices)companyservice;
        }


        [HttpGet("{id}")]
        public IActionResult getCompany([FromRoute] string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id)) return this.BadRequest();
                var valueBytes = System.Convert.FromBase64String(id);
                int idCompany = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                return this.Ok(JsonSerializer.Serialize<Company>(companyService.getCompany(idCompany)));
            }
            catch (Exception)
            {

                return this.Problem("invalid id", null, 500);
            }
        }

        [HttpGet("search")]
        public IActionResult searchCompany([FromQuery] string name= "")
        {
            if (string.IsNullOrEmpty(name)) return this.Problem("name is invalid",null,500);
            return this.Ok(JsonSerializer.Serialize(companyService.getCompanyByName(name)));
        }

        [HttpPost]
        public IActionResult addCompany([FromBody] Company newCompany, [FromServices] IValidation<Company> validation)
        {
            CompanyValidations modelValidator = (CompanyValidations)validation;

            try
            {
                modelValidator.ValidateEmptyNewModel(newCompany);
            }
            catch (Exception e)
            {
                return this.Problem(e.Message.ToString(), null, 500);
            }
            
            companyService.addCompany(newCompany);
            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult deleteCompany([FromRoute] string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id)) return this.BadRequest();
                var valueBytes = System.Convert.FromBase64String(id);
                int idCompany = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                companyService.deleteCompany(new Company() { Id = idCompany });
                return this.NoContent();
            }
            catch (Exception)
            {
                return this.Problem("invalid id", null, 500);
            }
            
        }

        [HttpPut]
        public IActionResult updateCompany([FromBody] Company model,[FromServices]IValidation<Company> validation)
        {
            CompanyValidations validations = (CompanyValidations)validation;
            try
            {
                validations.ValidateCompleteModel(model);
            }
            catch (Exception e)
            {
                return this.Problem(e.Message.ToString(), null, 500);
            }

            companyService.updateCompany(model);
            return this.NoContent();
        }
    }
}
