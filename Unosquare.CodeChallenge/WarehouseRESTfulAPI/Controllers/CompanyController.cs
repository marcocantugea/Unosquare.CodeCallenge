using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WarehouseServices.Services;
using WarehouseModels.Models;
using WarehouseServices.Contractor;
using System.Text;
using WarehouseModels.Interfaces;
using WarehouseModels.Validations;
using System.Text.Json;
using FluentValidation.Results;

namespace WarehouseRESTfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private CompaniesServices companyService;

        public CompanyController(IWarehouseService<CompaniesServices> companyservice)
        {
            companyService = (CompaniesServices)companyservice;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyAsync([FromRoute] string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id)) return this.BadRequest();
                var valueBytes = System.Convert.FromBase64String(id);
                int idCompany = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                return this.Ok(JsonSerializer.Serialize<Company>( await companyService.GetCompanyAsync(idCompany)));
            }
            catch (Exception)
            {

                return this.Problem("invalid id", null, 500);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCompanyAsync([FromQuery] string name= "")
        {
            if (string.IsNullOrEmpty(name)) return this.Problem("name is invalid",null,500);
            return this.Ok(JsonSerializer.Serialize(await companyService.GetCompanyByNameAsync(name)));
        }

        [HttpPost]
        public async Task<IActionResult> AddCompanyAsync([FromBody] Company newCompany, [FromServices] IValidation<Company> validation)
        {
            CompanyValidations modelValidator = (CompanyValidations)validation;

            try
            {
                ValidationResult result = await modelValidator.ValidateAsync(newCompany);
                if (!result.IsValid)
                {
                    string msg = "error validating data " + result.ToString(";");
                    return this.Problem(msg, null, 500);
                }
            }
            catch (Exception e)
            {
                return this.Problem(e.Message.ToString(), null, 500);
            }
            
            await companyService.AddCompanyAsync(newCompany);
            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyAsync([FromRoute] string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id)) return this.BadRequest();
                var valueBytes = System.Convert.FromBase64String(id);
                int idCompany = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                await companyService.DeleteCompanyAsync(new Company() { Id = idCompany });
                return this.NoContent();
            }
            catch (Exception)
            {
                return this.Problem("invalid id", null, 500);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompanyAsync([FromBody] Company model,[FromServices]IValidation<Company> validation)
        {
            CompanyValidations validations = (CompanyValidations)validation;
            validations.setRuleForId();
            try
            {
                ValidationResult result = await validations.ValidateAsync(model);
                if (!result.IsValid)
                {
                    string msg = "error validating data " + result.ToString(";");
                    return this.Problem(msg, null, 500);
                }
            }
            catch (Exception e)
            {
                return this.Problem(e.Message.ToString(), null, 500);
            }

            await companyService.UpdateCompanyAsync(model);
            return this.NoContent();
        }
    }
}
