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


        [HttpGet("{idEncoded}")]
        public async Task<IActionResult> GetCompanyAsync([FromRoute] string idEncoded)
        {
            try
            {
                if (String.IsNullOrEmpty(idEncoded)) return BadRequest();
                var valueBytes = System.Convert.FromBase64String(idEncoded);
                int idCompany = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                return Ok(await companyService.GetCompanyAsync(idCompany));
            }
            catch (Exception)
            {

                return Problem("invalid id", null, 500);
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCompanyAsync([FromQuery] string name= "")
        {
            if (string.IsNullOrEmpty(name)) return Problem("name is invalid",null,500);
            return Ok(await companyService.GetCompanyByNameAsync(name));
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
                    return Problem(msg, null, 500);
                }
            }
            catch (Exception e)
            {
                return Problem(e.Message.ToString(), null, 500);
            }
            
            await companyService.AddCompanyAsync(newCompany);
            return NoContent();
        }

        [HttpDelete("{idEncoded}")]
        public async Task<IActionResult> DeleteCompanyAsync([FromRoute] string idEncoded)
        {
            try
            {
                if (String.IsNullOrEmpty(idEncoded)) return BadRequest();
                var valueBytes = System.Convert.FromBase64String(idEncoded);
                int idCompany = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                await companyService.DeleteCompanyAsync(new Company() { id = idCompany });
                return NoContent();
            }
            catch (Exception)
            {
                return Problem("invalid id", null, 500);
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
                    return Problem(msg, null, 500);
                }
            }
            catch (Exception e)
            {
                return Problem(e.Message.ToString(), null, 500);
            }

            await companyService.UpdateCompanyAsync(model);
            return NoContent();
        }
    }
}
