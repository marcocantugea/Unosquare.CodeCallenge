using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests;
using WarehouseCoreLib.Repositories;

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

    }
}
