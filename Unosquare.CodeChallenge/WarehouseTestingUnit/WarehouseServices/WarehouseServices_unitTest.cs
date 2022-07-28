using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests;
using WarehouseCoreLib.DataAccess;
using WarehouseModels.Models;
using WarehouseServices.Services;
using Assert = NUnit.Framework.Assert;
using Theory = NUnit.Framework.TheoryAttribute;

namespace WarehouseTestingUnit.WarehouseServices
{
    public class WarehouseServices_unitTest
    {

        [Fact]
        public void Test_getAllCompanies_getAllCompaniesItems()
        {
            CompaniesServices service = new CompaniesServices(WarehouseHelper.createDBContext());
            List<Company> companies = service.GetAllCompanies().ToList();

            Assert.IsNotEmpty(companies);
            Assert.Greater(companies.Count, 0);
        }

        [Fact]
        public async void Test_getAllCompaniesAsync_getAllCompaniesItems()
        {
            CompaniesServices service = new CompaniesServices(WarehouseHelper.createDBContext());
            List<Company> companies = await  service.GetAllCompaniesAsync();

            Assert.IsNotEmpty(companies);
            Assert.Greater(companies.Count, 0);
        }

        [Fact]
        public void Test_GetCompany_GetItemCompanyById()
        {
            CompaniesServices service = new CompaniesServices(WarehouseHelper.createDBContext());
            Company company = service.GetCompany(1);

            Assert.AreEqual(1, company.Id);

        }

        [Fact]
        public async void Test_GetCompanyAsync_GetItemCompanyByID()
        {
            CompaniesServices service = new CompaniesServices(WarehouseHelper.createDBContext());
            Company company = await service.GetCompanyAsync(1);

            Assert.AreEqual(1, company.Id);
        }

        [Fact]
        public void Test_AddCompany_addItemToDb()
        {
            Company newCompany = new Company()
            {
                Name = "new company test unit"
            };

            CompaniesServices service = new CompaniesServices(WarehouseHelper.createDBContext());
            service.AddCompany(newCompany);
            Assert.True(true);
        }


        [Fact]
        public async void Test_AddCompanyAsync_addItemToDb()
        {
            Company newCompany = new Company()
            {
                Name = "new company test unit"
            };

            CompaniesServices service = new CompaniesServices(WarehouseHelper.createDBContext());
            await service.AddCompanyAsync(newCompany);
            Assert.True(true);
        }

        [Fact]
        public void Test_GetCompanyByName_getCompanyItem()
        {
            CompaniesServices service = new CompaniesServices(WarehouseHelper.createDBContext());
            Company company = service.GetCompanyByName("new company test unit");

            Assert.AreEqual("new company test unit", company.Name);
        }

        [Fact]
        public async void Test_GetCompanyByNameAsync_getCompanyItem()
        {
            CompaniesServices service = new CompaniesServices(WarehouseHelper.createDBContext());
            Company company = await service.GetCompanyByNameAsync("Mattel");

            Assert.AreEqual("Mattel", company.Name);
        }

        [Fact]
        public void Test_UpdateCompany_UpdateNameCompany()
        {
            CompaniesServices service = new CompaniesServices(WarehouseHelper.createDBContext());
            Company company = service.GetCompanyByName("new company test unit");
            company.Name = "new company test unit updated";
            service.UpdateCompany(company);

            Assert.IsTrue(true);

        }

        [Fact]
        public async void Test_UpdateCompanyAsync_UpdateNameCompany()
        {
            CompaniesServices service = new CompaniesServices(WarehouseHelper.createDBContext());
            Company company = await service.GetCompanyByNameAsync("new company test unit");
            company.Name = "new company test unit updated";
            await service.UpdateCompanyAsync(company);

            Assert.IsTrue(true);

        }

        [Fact]
        public void Test_DeleteCompany_DeleteCompany()
        {
            CompaniesServices service = new CompaniesServices(WarehouseHelper.createDBContext());
            Company company = service.GetCompanyByName("new company test unit updated");
            service.DeleteCompany(company);
            Assert.IsTrue(true);
        }

        [Fact]
        public async void Test_DeleteCompanyAsync_DeleteCompany()
        {
            CompaniesServices service = new CompaniesServices(WarehouseHelper.createDBContext());
            Company company = await service.GetCompanyByNameAsync("new company test unit updated");
            await service.DeleteCompanyAsync(company);
            Assert.IsTrue(true);
        }
    }
}
