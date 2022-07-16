using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests;
using WarehouseRepositories.Repositories;
using WarehouseModels.Models;

namespace WarehouseTestingUnit.WarehouseCoreLib.Repositories
{
    public class CompanyRepository_unitTest
    {
        [Fact]
        public void test_CompanyRepository_addCompany()
        {
            CompanyRepository repo = new CompanyRepository();
            repo.dbcontext = WarehouseHelper.createDBContext();
            repo.add(new WarehouseModels.Models.Company() {
                 Name="Lego"
            });
            repo.save();

            Assert.True(true);
        }

        [Fact]
        public void test_CompanyRepository_removeCompany()
        {
            CompanyRepository repo = new CompanyRepository();
            repo.dbcontext = WarehouseHelper.createDBContext();
            repo.delete(new WarehouseModels.Models.Company()
            {
                Id=6,
                Name = "Lego"
            });
            repo.save();

            Assert.True(true);
        }

        [Fact]
        public void test_CompanyRepository_updateCompany()
        {
            CompanyRepository repo = new CompanyRepository();
            repo.dbcontext = WarehouseHelper.createDBContext();
            WarehouseModels.Models.Company newCompany = new WarehouseModels.Models.Company()
            {
                Name = "Lego"
            };

            repo.add(newCompany);
            repo.save();

            newCompany.Id = 8;
            newCompany.Name = "Lego Inc.";

            repo.update(newCompany);
            repo.save();

            Assert.True(true);
        }

        [Fact]
        public void test_getById_getCompanyInfo()
        {
            CompanyRepository repo = new CompanyRepository();
            repo.dbcontext = WarehouseHelper.createDBContext();
            WarehouseModels.Models.Company companyFond = repo.getById(1);

            Assert.Equal("Mattel", companyFond.Name);
        }

        [Fact]
        public void test_getAll_getAllRecors()
        {
            CompanyRepository repo = new CompanyRepository();
            repo.dbcontext = WarehouseHelper.createDBContext();
            List<Company> listOfCompanies = repo.findAll().ToList();

            Assert.NotEmpty(listOfCompanies);
        }
    }
}

