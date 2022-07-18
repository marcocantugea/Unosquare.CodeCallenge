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
    public class product : ControllerBase
    {
        private ProductServices productService;

        public product(IWarehouseService<ProductServices> productService)
        {
                this.productService = (ProductServices)productService;
        }

        [HttpPost]
        public IActionResult addProduct([FromBody] ProductRequestModel requestModel,[FromServices]IValidation<Product> validation)
        {
            Product model = ProductRequestModel.getModel(requestModel);

            ProductValidations validations = (ProductValidations)validation;
            try
            {
                validations.ValidateNewProductModel(model);
            }
            catch (Exception e)
            {

                return this.Problem(e.Message.ToString(), null, 500);
            }

            productService.addProduct(model);
            return this.NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult getProduct([FromRoute] string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id)) return this.BadRequest();
                var valueBytes = System.Convert.FromBase64String(id);
                int productId = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                return this.Ok(JsonSerializer.Serialize(productService.getProduct(productId)));
            }
            catch (Exception)
            {

                return this.Problem("invalid id", null, 500);
            }
        }

        [HttpGet("list")]
        public IActionResult getProducts()
        {
            return this.Ok(JsonSerializer.Serialize(productService.getProducts()));
        }

        [HttpPut("{id}")]
        public IActionResult updateProduct([FromRoute] string id, [FromBody] ProductRequestModel productUpdate)
        {
            try
            {
                if (String.IsNullOrEmpty(id)) return this.BadRequest();
                var valueBytes = System.Convert.FromBase64String(id);
                int productId = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                Product productToUpdate = ProductRequestModel.getModel(productUpdate);
                productToUpdate.id=productId;
                productService.updateProduct(productToUpdate);
            }
            catch (Exception)
            {

                return this.Problem("invalid id", null, 500);
            }

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult deleteProduct([FromRoute]string id)
        {
            try
            {
                if (String.IsNullOrEmpty(id)) return this.BadRequest();
                var valueBytes = System.Convert.FromBase64String(id);
                int productId = Int32.Parse(Encoding.UTF8.GetString(valueBytes));
                productService.deleteProduct(productId);
            }
            catch (Exception)
            {
                return this.Problem("invalid id", null, 500);
            }
            return this.NoContent();
        }
    }
}
