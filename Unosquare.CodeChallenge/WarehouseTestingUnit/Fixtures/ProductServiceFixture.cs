using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests;
using WarehouseServices.Services;

namespace WarehouseTestingUnit.Fixtures
{
    public class ProductServiceFixture
    {
        public ProductServices productService => new ProductServices(WarehouseHelper.createDBContext());

        public ProductServices GetService()
        {
            return productService;
        }
    }
}
