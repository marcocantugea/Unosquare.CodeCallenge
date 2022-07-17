﻿using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WarehouseModels.Models;
using Xunit.Abstractions;

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
    }
}