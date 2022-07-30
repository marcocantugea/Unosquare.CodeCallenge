using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests;
using WarehouseServices.Services;

namespace WarehouseTestingUnit.Fixtures
{
    public class CompanyServiceFixture
    {
        private CompaniesServices serviceCompany => new CompaniesServices(WarehouseHelper.createDBContext());

        public CompaniesServices GetService()
        {
            return serviceCompany;
        }
    }
}
