using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WarehouseCoreLib.DataAccess;
using WarehouseModels.Models;
using WarehouseServices.Contractor;
using WarehouseServices.Services;
using WarehouseTestingUnit.Fixtures;
using Xunit.Abstractions;

namespace WarehouseTestingUnit.WarehouseRESTfulAPI
{
    public class CompanyController_IntegrationTest: IClassFixture<WebApplicationFixture>
    {
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _output;

        public CompanyController_IntegrationTest(WebApplicationFixture webApplicationFixture,ITestOutputHelper output)
        {
            _output = output;
            _client = webApplicationFixture.GetWebApplicationFactory().CreateClient();
        }


        [Fact]
        public async void AddCompany_SuccessAddCompany()
        {
            var client = _client;
            Company newCompany = new Company()
            {
                name = "PlayDoh"
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Company>(newCompany));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/company", content);

            Assert.Equal(HttpStatusCode.NoContent, responsePost.StatusCode);
        }

        [Fact]
        public async void AddCompany_ValidatorNameEmpty()
        {
            var client = _client;
            Company newCompany = new Company()
            {
                name = ""
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Company>(newCompany));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/company", content);

            Assert.Equal(HttpStatusCode.InternalServerError, responsePost.StatusCode);
        }

        [Fact]
        public async void RemoveCompany_RemoveSuccess()
        {
            var client = _client;
            Company newCompany = new Company()
            {
                name = "Patito"
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Company>(newCompany));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responsePost = await client.PostAsync("api/company", content);
            var responseSearch = await client.GetAsync("api/company/search?name=" + newCompany.name);
            var responseJson = await responseSearch.Content.ReadAsStringAsync();
            Company companyTodelete = JsonSerializer.Deserialize<Company>(responseJson);
            var valueBytes = Encoding.UTF8.GetBytes(companyTodelete.id.ToString());
            string idbase = Convert.ToBase64String(valueBytes);
            var responseDelete = await client.DeleteAsync("api/company/"+ idbase);

            Assert.Equal(HttpStatusCode.NoContent, responseDelete.StatusCode);
        }

        [Fact]
        public async void UpdateCompanyItem_UpdatesSucess()
        {
            var client = _client;
            Company newCompany = new Company()
            {
                name = "Patito"
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Company>(newCompany));
            content.Headers.ContentType= new MediaTypeHeaderValue("application/json");

            var responsePost = await client.PostAsync("api/company", content);
            var responseSearch = await client.GetAsync("api/company/search?name=" + newCompany.name);
            var responseJson = await responseSearch.Content.ReadAsStringAsync();

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Company companyUpdate = JsonSerializer.Deserialize<Company>(responseJson);
            companyUpdate.name = "DisneyInc.";
            HttpContent jsoncontent = new StringContent(JsonSerializer.Serialize<Company>(companyUpdate));
            jsoncontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseUpdate = await client.PutAsync("api/company",jsoncontent);

            Assert.Equal(HttpStatusCode.NoContent, responseUpdate.StatusCode);
        }


        [Fact]
        public async void UpdateCompany_ValidatorIdZero()
        {
            var client = _client;
            Company newCompany = new Company()
            {
                name = "Patito"
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Company>(newCompany));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var responsePost = await client.PostAsync("api/company", content);
            var responseSearch = await client.GetAsync("api/company/search?name=" + newCompany.name);
            var responseJson = await responseSearch.Content.ReadAsStringAsync();

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Company companyUpdate = JsonSerializer.Deserialize<Company>(responseJson);
            companyUpdate.id = 0;
            companyUpdate.name = "DisneyInc.";
            HttpContent jsoncontent = new StringContent(JsonSerializer.Serialize<Company>(companyUpdate));
            jsoncontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseUpdate = await client.PutAsync("api/company", jsoncontent);

            Assert.Equal(HttpStatusCode.InternalServerError, responseUpdate.StatusCode);
        }

        [Fact]
        public async void UpdateCompany_ValidatorNameEmpty()
        {
            var client =_client;
            Company newCompany = new Company()
            {
                name = "Patito"
            };


            HttpContent content = new StringContent(JsonSerializer.Serialize<Company>(newCompany));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var responsePost = await client.PostAsync("api/company", content);
            var responseSearch = await client.GetAsync("api/company/search?name=" + newCompany.name);
            var responseJson = await responseSearch.Content.ReadAsStringAsync();

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Company companyUpdate = JsonSerializer.Deserialize<Company>(responseJson);
            companyUpdate.name = "";
            HttpContent jsoncontent = new StringContent(JsonSerializer.Serialize<Company>(companyUpdate));
            jsoncontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var responseUpdate = await client.PutAsync("api/company", jsoncontent);

            Assert.Equal(HttpStatusCode.InternalServerError, responseUpdate.StatusCode);
        }

        [Fact]
        public async void GetCompanyById_GetCompanyItem()
        {
            var client = _client;

            var responseSearch = await client.GetAsync("api/company/search?name=Mattel");
            var responseJson = await responseSearch.Content.ReadAsStringAsync();
            Company companyToSearch = JsonSerializer.Deserialize<Company>(responseJson);
            var valueBytes = Encoding.UTF8.GetBytes(companyToSearch.id.ToString());
            string idbase = Convert.ToBase64String(valueBytes);

            var responseCompanyIdFound = await client.GetAsync("api/company/" + idbase);
            var jsonreponse = await responseCompanyIdFound.Content.ReadAsStringAsync();
            Company companyFound = JsonSerializer.Deserialize<Company>(jsonreponse);

            Assert.Equal(HttpStatusCode.OK, responseCompanyIdFound.StatusCode);
            Assert.Equal(1, companyFound.id);
        }
    }

}