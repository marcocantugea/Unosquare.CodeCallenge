using Microsoft.AspNetCore.Mvc.Testing;
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
using WarehouseTestingUnit.Fixtures;

namespace WarehouseTestingUnit.WarehouseRESTfulAPI
{
    public class ProductController_IntegrationTest: IClassFixture<WebApplicationFixture>
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        public ProductController_IntegrationTest(WebApplicationFixture  webApplicationFixture,ITestOutputHelper output)
        {
            _output = output;
            _client = webApplicationFixture.GetWebApplicationFactory().CreateClient();
        }

        [Fact]
        public async void AddProduct_AddItemSuccess()
        {
            var client = _client;
            Product newProduct = new Product()
            {
                Name = " Mercedes Benz A Class Blue 2022",
                Description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                AgeRestriction = 5,
                CompanyId = 2,
                ImageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                Price = 221.50m,
                Storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.NoContent, responsePost.StatusCode);
        }

        [Fact]
        public async void AddProduct_TestValidatorNameEmpty()
        {
            var client = _client;
            Product newProduct = new Product()
            {
                Name = "",
                Description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                AgeRestriction = 5,
                CompanyId = 2,
                ImageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                Price = 221.50m,
                Storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
        }

        [Fact]
        public async void AddProduct_TestValidatorNameMore50Chars()
        {
            var client = _client;
            Product newProduct = new Product()
            {
                Name = "Note ValidateAndThrow is an extension method, so you must have the FluentValidation namespace imported with a using statement at the top of your file in order for this method to be available.",
                Description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                AgeRestriction = 5,
                CompanyId = 2,
                ImageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                Price = 221.50m,
                Storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
        }

        [Fact]
        public async void AddProduct_TestValidatorAgeRestictionEmpty()
        {
            var client = _client;
            Product newProduct = new Product()
            {
                Name = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                Description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                AgeRestriction = 0,
                CompanyId = 2,
                ImageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                Price = 221.50m,
                Storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
        }

        [Fact]
        public async void AddProduct_TestValidatorAgeRestictionGreaterThan100()
        {
            var client = _client;
            Product newProduct = new Product()
            {
                Name = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                Description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                AgeRestriction = 500,
                CompanyId = 2,
                ImageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                Price = 221.50m,
                Storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
        }

        [Fact]
        public async void AddProduct_TestValidatorPriceZero()
        {
            var client = _client;
            Product newProduct = new Product()
            {
                Name = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                Description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                AgeRestriction = 19,
                CompanyId = 2,
                ImageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                Price = 0,
                Storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
        }

        [Fact]
        public async void AddProduct_TestValidatorCompanyIdZero()
        {
            var client = _client;
            Product newProduct = new Product()
            {
                Name = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                Description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                AgeRestriction = 19,
                CompanyId = 0,
                ImageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                Price = 221.50m,
                Storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
        }

        [Fact]
        public async void AddProduct_TestValidatorDescriptionMaxLenth100()
        {
            var client = _client;
            Product newProduct = new Product()
            {
                Name = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                Description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022 Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022 Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022 Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022 Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                AgeRestriction = 19,
                CompanyId = 1,
                ImageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                Price = 221.50m,
                Storeid = 1
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
        }

        [Fact]
        public async void AddProducts_AddItemsSuccess()
        {
            var client = _client;
            List<Product> products = new List<Product>();

            Product newProduct1 = new Product()
            {
                Name = "Toy test 1",
                Description = "Toy test 1",
                AgeRestriction = 1,
                CompanyId = 2,
                ImageIurl = "",
                Price = 1.50m,
                Storeid = 1
            };
            Product newProduct2 = new Product()
            {
                Name = "Toy test 2",
                Description = "Toy test 2",
                AgeRestriction = 1,
                CompanyId = 2,
                ImageIurl = "",
                Price = 1.50m,
                Storeid = 1
            };
            Product newProduct3 = new Product()
            {
                Name = "Toy test 3",
                Description = "Toy test 3",
                AgeRestriction = 1,
                CompanyId = 2,
                ImageIurl = "",
                Price = 1.50m,
                Storeid = 1
            };

            Product newProduct4 = new Product()
            {
                Name = "Toy test 4",
                Description = "Toy test 4",
                AgeRestriction = 1,
                CompanyId = 2,
                ImageIurl = "",
                Price = 1.50m,
                Storeid = 1
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
        public async void GetProduct_GetProductObj()
        {
            var client = _client;
            var responseGet = await client.GetAsync("api/product/MQ==");
            var responseJson = await responseGet.Content.ReadAsStringAsync();
            Product product = JsonSerializer.Deserialize<Product>(responseJson);

            _output.WriteLine(responseJson);

            Assert.Equal(HttpStatusCode.OK, responseGet.StatusCode);
            Assert.Equal(1, product.Id);
            
        }

        [Fact]
        public async void UpdateProduct_UpdateProductInfo()
        {
            Product productToUpdate = new Product()
            {
                Name = "Toy test 5",
                Description = "Toy test 5",
                AgeRestriction = 1,
                CompanyId = 2,
                ImageIurl = "",
                Price = 1.50m,
                Storeid = 1
            };

            var client = _client;
            HttpContent content = new StringContent(JsonSerializer.Serialize(productToUpdate));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseUpdate = await client.PutAsync("api/product/MQ==",content);

            Assert.Equal(HttpStatusCode.NoContent, responseUpdate.StatusCode);
        }


        [Fact]
        public async void DeleteProduct_DeleteProductSuccess()
        {
            Product newProduct = new Product()
            {
                Name = "Toy test 6",
                Description = "Toy test 6",
                AgeRestriction = 1,
                CompanyId = 2,
                ImageIurl = "",
                Price = 1.50m,
                Storeid = 1
            };

            var client = _client;

            HttpContent content = new StringContent(JsonSerializer.Serialize<Product>(newProduct));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/product", content);

            var responseAllOrdes = await client.GetAsync("api/products");
            var responseJson = await responseAllOrdes.Content.ReadAsStringAsync();
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(responseJson);

            var valueBytes = Encoding.UTF8.GetBytes(products.Last().Id.ToString());
            string idbase = Convert.ToBase64String(valueBytes);

            var responseUpdate = await client.DeleteAsync("api/product/"+ idbase);

            Assert.Equal(HttpStatusCode.NoContent, responseUpdate.StatusCode);
        }

        [Fact]
        public async void SearchProduct_ObtainDataFromFilter()
        {
            ProductFilterRequestModel model = new ProductFilterRequestModel();
            model.field = "name";
            model.value = "MARVEL";
            model.typeField = (int)typeFields.STRING;
            model.whereOperator = "contains";

            List<ProductFilterRequestModel> filters = new List<ProductFilterRequestModel>();
            filters.Add(model);

            var client = _client;
            //HttpContent content = new StringContent(JsonSerializer.Serialize(filters));
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpContent content = new StringContent(JsonSerializer.Serialize(filters));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/products/search", content);


            Assert.Equal(HttpStatusCode.OK, responsePost.StatusCode);
        }
    }
}
