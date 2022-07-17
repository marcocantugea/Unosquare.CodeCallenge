using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return this.Ok();
        }
    }
}
