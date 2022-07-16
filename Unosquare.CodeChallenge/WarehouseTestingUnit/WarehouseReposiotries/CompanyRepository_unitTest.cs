using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests;
using WarehouseModels.Models;
using WarehouseRepositories.Repositories;

namespace WarehouseTestingUnit.WarehouseReposiotries
{
    public class CompanyRepository_unitTest
    {
        [Fact]
        public void test_getCompanyByName_getCompanyObj()
        {
            CompanyRepository repo = new CompanyRepository();
            repo.dbcontext= WarehouseHelper.createDBContext();
            Company company = repo.getCompanyByName("Mattel");
            Assert.Equal(1, company.Id);
        }
    }
}
