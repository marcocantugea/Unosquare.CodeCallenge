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
    public class companyController_IntegrationTest
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly ITestOutputHelper _output;

        public companyController_IntegrationTest(ITestOutputHelper output)
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

            Assert.Equal(HttpStatusCode.NoContent, responsePost.StatusCode);
        }

        [Fact]
        public async void test_addCompany_ValidatorNameEmpty()
        {
            var client = _factory.CreateClient();
            Company newCompany = new Company()
            {
                Name = ""
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Company>(newCompany));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/company", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
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

            Assert.Equal(HttpStatusCode.NoContent, responseDelete.StatusCode);
        }

        [Fact]
        public async void test_updateCompanyItem_UpdatesSucess()
        {
            var client = _factory.CreateClient();
            Company newCompany = new Company()
            {
                Name = "Patito"
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Company>(newCompany));
            content.Headers.ContentType= new MediaTypeHeaderValue("application/json");

            var responsePost = await client.PostAsync("api/company", content);
            var responseSearch = await client.GetAsync("api/company/search?name=" + newCompany.Name);
            var responseJson = await responseSearch.Content.ReadAsStringAsync();

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Company companyUpdate = JsonSerializer.Deserialize<Company>(responseJson);
            companyUpdate.Name = "DisneyInc.";
            HttpContent jsoncontent = new StringContent(JsonSerializer.Serialize<Company>(companyUpdate));
            jsoncontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseUpdate = await client.PutAsync("api/company",jsoncontent);

            Assert.Equal(HttpStatusCode.NoContent, responseUpdate.StatusCode);
        }


        [Fact]
        public async void test_updateCompany_ValidatorIdZero()
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

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Company companyUpdate = JsonSerializer.Deserialize<Company>(responseJson);
            companyUpdate.Id = 0;
            companyUpdate.Name = "DisneyInc.";
            HttpContent jsoncontent = new StringContent(JsonSerializer.Serialize<Company>(companyUpdate));
            jsoncontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseUpdate = await client.PutAsync("api/company", jsoncontent);

            Assert.Equal(HttpStatusCode.InternalServerError, responseUpdate.StatusCode);
        }

        [Fact]
        public async void test_updateCompany_ValidatorNameEmpty()
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

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Company companyUpdate = JsonSerializer.Deserialize<Company>(responseJson);
            companyUpdate.Name = "";
            HttpContent jsoncontent = new StringContent(JsonSerializer.Serialize<Company>(companyUpdate));
            jsoncontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseUpdate = await client.PutAsync("api/company", jsoncontent);

            Assert.Equal(HttpStatusCode.InternalServerError, responseUpdate.StatusCode);
        }

        [Fact]
        public async void test_getCompanyById_getCompanyItem()
        {
            var client = _factory.CreateClient();

            var responseSearch = await client.GetAsync("api/company/search?name=Mattel");
            var responseJson = await responseSearch.Content.ReadAsStringAsync();
            Company companyToSearch = JsonSerializer.Deserialize<Company>(responseJson);
            var valueBytes = Encoding.UTF8.GetBytes(companyToSearch.Id.ToString());
            string idbase = Convert.ToBase64String(valueBytes);

            var responseCompanyIdFound = await client.GetAsync("api/company/" + idbase);
            var jsonreponse = await responseCompanyIdFound.Content.ReadAsStringAsync();
            Company companyFound = JsonSerializer.Deserialize<Company>(jsonreponse);

            Assert.Equal(HttpStatusCode.OK, responseCompanyIdFound.StatusCode);
            Assert.Equal(1, companyFound.Id);
        }
    }

}