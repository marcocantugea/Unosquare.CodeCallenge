﻿using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Linq;
using System.Threading.Tasks;
using WarehouseModels.Models;
using Xunit.Abstractions;
using WarehouseRESTfulAPI.RequestModels;
using System.Net.Mime;

namespace WarehouseTestingUnit.WarehouseRESTfulAPI
{
    public class ProductController_integrationTest
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly ITestOutputHelper _output;

        public ProductController_integrationTest(ITestOutputHelper output)
        {
            _output = output;
            _factory = new WebApplicationFactory<Program>();
        }

        [Fact]
        public async void test_addProduct_addItemSuccess()
        {
            var client = _factory.CreateClient();
            Product newProduct = new Product()
            {
                name = " Mercedes Benz A Class Blue 2022",
                description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                ageRestriction = 5,
                companyId = 2,
                imageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                price = 221.50m,
                storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.OK, responsePost.StatusCode);
        }

        [Fact]
        public async void test_addProduct_TestValidatorNameEmpty()
        {
            var client = _factory.CreateClient();
            Product newProduct = new Product()
            {
                name = "",
                description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                ageRestriction = 5,
                companyId = 2,
                imageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                price = 221.50m,
                storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
        }

        [Fact]
        public async void test_addProduct_TestValidatorNameMore50Chars()
        {
            var client = _factory.CreateClient();
            Product newProduct = new Product()
            {
                name = "Note ValidateAndThrow is an extension method, so you must have the FluentValidation namespace imported with a using statement at the top of your file in order for this method to be available.",
                description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                ageRestriction = 5,
                companyId = 2,
                imageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                price = 221.50m,
                storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
        }

        [Fact]
        public async void test_addProduct_TestValidatorAgeRestictionEmpty()
        {
            var client = _factory.CreateClient();
            Product newProduct = new Product()
            {
                name = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                ageRestriction = 0,
                companyId = 2,
                imageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                price = 221.50m,
                storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
        }

        [Fact]
        public async void test_addProduct_TestValidatorAgeRestictionGreaterThan100()
        {
            var client = _factory.CreateClient();
            Product newProduct = new Product()
            {
                name = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                ageRestriction = 500,
                companyId = 2,
                imageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                price = 221.50m,
                storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
        }

        [Fact]
        public async void test_addProduct_TestValidatorPriceZero()
        {
            var client = _factory.CreateClient();
            Product newProduct = new Product()
            {
                name = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                ageRestriction = 19,
                companyId = 2,
                imageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                price = 0,
                storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
        }

        [Fact]
        public async void test_addProduct_TestValidatorCompanyIdZero()
        {
            var client = _factory.CreateClient();
            Product newProduct = new Product()
            {
                name = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                ageRestriction = 19,
                companyId = 0,
                imageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                price = 221.50m,
                storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
        }

        [Fact]
        public async void test_addProduct_TestValidatorDescriptionMaxLenth100()
        {
            var client = _factory.CreateClient();
            Product newProduct = new Product()
            {
                name = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022 Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022 Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022 Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022 Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                ageRestriction = 19,
                companyId = 1,
                imageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                price = 221.50m,
                storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
        }

        [Fact]
        public async void test_addProducts_addItemsSuccess()
        {
            var client = _factory.CreateClient();
            List<Product> products = new List<Product>();

            Product newProduct1 = new Product()
            {
                name = "Toy test 1",
                description = "Toy test 1",
                ageRestriction = 1,
                companyId = 2,
                imageIurl = "",
                price = 1.50m,
                storeid = 1
            };
            Product newProduct2 = new Product()
            {
                name = "Toy test 2",
                description = "Toy test 2",
                ageRestriction = 1,
                companyId = 2,
                imageIurl = "",
                price = 1.50m,
                storeid = 1
            };
            Product newProduct3 = new Product()
            {
                name = "Toy test 3",
                description = "Toy test 3",
                ageRestriction = 1,
                companyId = 2,
                imageIurl = "",
                price = 1.50m,
                storeid = 1
            };

            Product newProduct4 = new Product()
            {
                name = "Toy test 4",
                description = "Toy test 4",
                ageRestriction = 1,
                companyId = 2,
                imageIurl = "",
                price = 1.50m,
                storeid = 1
            };
            
            products.Add(newProduct1);
            products.Add(newProduct2);
            products.Add(newProduct3);
            products.Add(newProduct4);

            HttpContent content = new StringContent(JsonSerializer.Serialize(products));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/products", content);

            Assert.Equal(HttpStatusCode.NoContent, responsePost.StatusCode);
        }

        [Fact]
        public async void test_getProduct_GetProductObj()
        {
            var client = _factory.CreateClient();
            var responseGet = await client.GetAsync("api/product/MQ==");
            var responseJson = await responseGet.Content.ReadAsStringAsync();
            Product product = JsonSerializer.Deserialize<Product>(responseJson);

            _output.WriteLine(responseJson);

            Assert.Equal(HttpStatusCode.OK, responseGet.StatusCode);
            Assert.Equal(1, product.id);
            
        }

        [Fact]
        public async void test_updateProduct_updateProductInfo()
        {
            Product productToUpdate = new Product()
            {
                name = "Toy test 5",
                description = "Toy test 5",
                ageRestriction = 1,
                companyId = 2,
                imageIurl = "",
                price = 1.50m,
                storeid = 1
            };

            var client = _factory.CreateClient();
            HttpContent content = new StringContent(JsonSerializer.Serialize(productToUpdate));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseUpdate = await client.PutAsync("api/product/MQ==",content);

            Assert.Equal(HttpStatusCode.NoContent, responseUpdate.StatusCode);
        }


        [Fact]
        public async void test_deleteProduct_deleteProductSuccess()
        {
            Product newProduct = new Product()
            {
                name = "Toy test 6",
                description = "Toy test 6",
                ageRestriction = 1,
                companyId = 2,
                imageIurl = "",
                price = 1.50m,
                storeid = 1
            };

            var client = _factory.CreateClient();

            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            var responseAllOrdes = await client.GetAsync("api/products");
            var responseJson = await responseAllOrdes.Content.ReadAsStringAsync();
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(responseJson);

            var valueBytes = Encoding.UTF8.GetBytes(products.Last().id.ToString());
            string idbase = Convert.ToBase64String(valueBytes);

            var responseUpdate = await client.DeleteAsync("api/product/"+ idbase);

            Assert.Equal(HttpStatusCode.NoContent, responseUpdate.StatusCode);
        }

        [Fact]
        public async void test_searchProduct_searchProductsList()
        {
            ProductFilterRequestModel model = new ProductFilterRequestModel();
            model.field = "name";
            model.value = "MARVEL";
            model.typeField = (int)typeFields.STRING;
            model.whereOperator = "contains";

            List<ProductFilterRequestModel> filters = new List<ProductFilterRequestModel>();
            filters.Add(model);

            var client = _factory.CreateClient();
            //HttpContent content = new StringContent(JsonSerializer.Serialize(filters));
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpContent content = new StringContent(JsonSerializer.Serialize(filters));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/products/search", content);


            Assert.Equal(HttpStatusCode.OK, responsePost.StatusCode);
        }
    }
}
