using AutoMapper;
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
        private readonly ProductServices _productService;

        public ProductController(IWarehouseService<ProductServices> productService)
        {
                this._productService = (ProductServices)productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequestModel requestModel,[FromServices]IValidation<Product> validation, [FromServices] IMapper mapper)
        {
            Product model = mapper.Map<Product>(requestModel); // ProductRequestModel.getModel(requestModel);


            ProductValidations validations = (ProductValidations)validation;
            try
            {
                ValidationResult result= await validations.ValidateAsync(model);
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

            await _productService.AddProductAsync(model);
            return NoContent();
        }

        [HttpGet("{idEncoded}")]
        public async Task<IActionResult> GetProduct([FromRoute] string idEncoded)
        {
            try
            {
                if (String.IsNullOrEmpty(idEncoded)) return BadRequest();
                var valueBytes = System.Convert.FromBase64String(idEncoded);
                int productId = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                return Ok(await _productService.GetProductAsync(productId));
            }
            catch (Exception)
            {

                return Problem("invalid id", null, 500);
            }
        }

        [HttpGet("list")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productService.GetProductsAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] string id, [FromBody] ProductRequestModel productUpdate, [FromServices] IValidation<Product> validation,[FromServices] IMapper mapper)
        {
            try
            {
                ProductValidations validations = (ProductValidations)validation;

                if (String.IsNullOrEmpty(id)) return BadRequest();
                var valueBytes = System.Convert.FromBase64String(id);
                int productId = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                Product productToUpdate = mapper.Map<Product>(productUpdate);
                try
                {
                    ValidationResult result = await validations.ValidateAsync(productToUpdate);
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
                productToUpdate.Id=productId;
                await _productService.UpdateProductAsync(productToUpdate);
            }
            catch (Exception)
            {

                return Problem("invalid id", null, 500);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute]string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id)) return BadRequest();
                var valueBytes = System.Convert.FromBase64String(id);
                int productId = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                await _productService.DeleteProductAsync(productId);
            }
            catch (Exception)
            {
                return Problem("invalid id", null, 500);
            }
            return NoContent();
        }
    }
}
