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
        private CompaniesServices _serviceCompany;

        public CompanyServiceFixture()
        {
            WarehouseDbContextFixture dbContextFixture = new WarehouseDbContextFixture();
            _serviceCompany = new CompaniesServices(dbContextFixture.GetDbContext());
        }

        public CompaniesServices GetService()
        {
            return _serviceCompany;
        }

        public static CompaniesServices GetServiceCompany()
        {
            return new CompanyServiceFixture().GetService();
        }
    }
}
