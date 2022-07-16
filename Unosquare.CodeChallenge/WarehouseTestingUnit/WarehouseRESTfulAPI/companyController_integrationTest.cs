using Microsoft.AspNetCore.Mvc.Testing;
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
    public class companyController_integrationTest
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly ITestOutputHelper _output;

        public companyController_integrationTest(ITestOutputHelper output)
        {
            _output = output;
            _factory = new WebApplicationFactory<Program>();
        }


        [Fact]
        public async void test_companyController_successAddCompany()
        {
            var client = _factory.CreateClient();
            Company newCompany = new Company()
            {
                Name = "PlayDoh"
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Company>(newCompany));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/company", content);

            Assert.Equal(HttpStatusCode.OK, responsePost.StatusCode);
        }

        [Fact]
        public async void test_addCompanyRemoveNew_removeSuccess()
        {
            var client = _factory.CreateClient();
            Company newCompany = new Company()
            {
                Name = "Patito"
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Company>(newCompany));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/company", content);
            var responseSearch = await client.GetAsync("api/company/search?name=" + newCompany.Name);
            var responseJson = await responseSearch.Content.ReadAsStringAsync();
            Company companyTodelete = JsonSerializer.Deserialize<Company>(responseJson);
            var valueBytes = Encoding.UTF8.GetBytes(companyTodelete.Id.ToString());
            string idbase = Convert.ToBase64String(valueBytes);
            var responseDelete = await client.DeleteAsync("api/company/"+ idbase);

            Assert.Equal(HttpStatusCode.OK, responseDelete.StatusCode);
        }
    }
}
