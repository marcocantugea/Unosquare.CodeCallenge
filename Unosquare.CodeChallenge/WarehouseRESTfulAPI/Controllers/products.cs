﻿using FluentValidation.Results;
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
    public class products : ControllerBase
    {

        private ProductServices productService;

        public products(IWarehouseService<ProductServices> productService)
        {
            this.productService = (ProductServices)productService;
        }

        [HttpGet]
        public IActionResult getProducts() {
            return this.Ok(JsonSerializer.Serialize(productService.getProducts()));

        }

        [HttpPost("search")]
        public IActionResult searchProducts([FromBody] ProductFilterRequestModel[] filters)
        {
            //por cada filtro los convertimos a linq expression
            List<Func<IProduct, bool>> linqFilters = new List<Func<IProduct, bool>>();
            try
            {
                linqFilters.Add(FiltersConverter.convertToLinqExpression(FiltersConverter.getLinqExpressions(filters)));
            }
            catch (Exception exception)
            {
                this.BadRequest(exception);
            }
            
            return this.Ok(JsonSerializer.Serialize(productService.searchProducts(linqFilters)));

        }

        [HttpPost]
        public IActionResult postProducts([FromBody] IEnumerable<ProductRequestModel> productsRequested,[FromServices]IValidation<Product> validation) {

            List<Product> products = new List<Product>();
            foreach (ProductRequestModel productRequested in productsRequested)
            {
                products.Add(ProductRequestModel.getModel(productRequested));
            }

            ProductValidations validations = (ProductValidations)validation; 
            foreach (Product product in products) {
                try
                {
                    ValidationResult result = validations.Validate(product);
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

            }

            try
            {
                productService.addProducts(products);
            }
            catch (Exception e)
            {
                return this.Problem(e.Message.ToString(), null, 500);
            }

            return this.NoContent();

        }
    }
}
