using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WarehouseModels.Interfaces;
using WarehouseModels.Models;
using WarehouseModels.Validations;
using WarehouseRESTfulAPI.Helpers;
using WarehouseRESTfulAPI.RequestModels;
using WarehouseServices.Contractor;
using WarehouseServices.Services;

namespace WarehouseRESTfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private ProductServices _productService;

        public ProductsController(IWarehouseService<ProductServices> productService)
        {
            this._productService = (ProductServices)productService;
        }

        [HttpGet]
        public IActionResult GetProducts() {
            return Ok(_productService.GetProducts());

        }

        [HttpPost("search")]
        public IActionResult SearchProducts([FromBody] ProductFilterRequestModel[] filters)
        {
            //por cada filtro los convertimos a linq expression
            List<Func<IProduct, bool>> linqFilters = new List<Func<IProduct, bool>>();
            try
            {
                linqFilters.Add(FiltersConverter.convertToLinqExpression(FiltersConverter.getLinqExpressions(filters)));
            }
            catch (Exception exception)
            {
                BadRequest(exception);
            }
            
            return Ok(_productService.Search(linqFilters));

        }

        [HttpPost]
        public async Task<IActionResult> PostProducts([FromBody] IEnumerable<ProductRequestModel> productsRequested,[FromServices]IValidation<Product> validation) {

            List<Product> products = new List<Product>();
            foreach (ProductRequestModel productRequested in productsRequested)
            {
                products.Add(ProductRequestModel.getModel(productRequested));
            }

            ProductValidations validations = (ProductValidations)validation; 
            foreach (Product product in products) {
                try
                {
                    ValidationResult result = await validations.ValidateAsync(product);
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

            }

            try
            {
                await _productService.AddProductsAsync(products);
            }
            catch (Exception e)
            {
                return Problem(e.Message.ToString(), null, 500);
            }

            return NoContent();

        }
    }
}
