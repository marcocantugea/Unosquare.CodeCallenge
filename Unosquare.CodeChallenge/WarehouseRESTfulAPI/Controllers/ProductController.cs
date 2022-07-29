using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using WarehouseModels.Interfaces;
using WarehouseModels.Models;
using WarehouseModels.Validations;
using WarehouseRESTfulAPI.RequestModels;
using WarehouseServices.Contractor;
using WarehouseServices.Services;

namespace WarehouseRESTfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductServices productService;

        public ProductController(IWarehouseService<ProductServices> productService)
        {
                this.productService = (ProductServices)productService;
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductRequestModel requestModel,[FromServices]IValidation<Product> validation)
        {
            Product model = ProductRequestModel.getModel(requestModel);

            ProductValidations validations = (ProductValidations)validation;
            try
            {
                ValidationResult result= validations.Validate(model);
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

            productService.AddProduct(model);
            return NoContent();
        }

        [HttpGet("{idEncoded}")]
        public IActionResult GetProduct([FromRoute] string idEncoded)
        {
            try
            {
                if (String.IsNullOrEmpty(idEncoded)) return BadRequest();
                var valueBytes = System.Convert.FromBase64String(idEncoded);
                int productId = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                return Ok(JsonSerializer.Serialize(productService.GetProduct(productId)));
            }
            catch (Exception)
            {

                return Problem("invalid id", null, 500);
            }
        }

        [HttpGet("list")]
        public IActionResult GetProducts()
        {
            return Ok(JsonSerializer.Serialize(productService.GetProducts()));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct([FromRoute] string id, [FromBody] ProductRequestModel productUpdate, [FromServices] IValidation<Product> validation)
        {
            try
            {
                ProductValidations validations = (ProductValidations)validation;

                if (String.IsNullOrEmpty(id)) return BadRequest();
                var valueBytes = System.Convert.FromBase64String(id);
                int productId = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                Product productToUpdate = ProductRequestModel.getModel(productUpdate);
                try
                {
                    ValidationResult result = validations.Validate(productToUpdate);
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
                productToUpdate.id=productId;
                productService.UpdateProduct(productToUpdate);
            }
            catch (Exception)
            {

                return Problem("invalid id", null, 500);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct([FromRoute]string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id)) return BadRequest();
                var valueBytes = System.Convert.FromBase64String(id);
                int productId = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                productService.DeleteProduct(productId);
            }
            catch (Exception)
            {
                return Problem("invalid id", null, 500);
            }
            return NoContent();
        }
    }
}
