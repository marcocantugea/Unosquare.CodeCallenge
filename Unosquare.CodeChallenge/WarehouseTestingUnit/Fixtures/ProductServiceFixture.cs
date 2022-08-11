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
        private readonly ProductServices _productService;

        public ProductServiceFixture()
        {
            WarehouseDbContextFixture dbContextFixture= new WarehouseDbContextFixture();
            _productService = new ProductServices(dbContextFixture.GetDbContext());
        }

        public ProductServices GetService()
        {
            return _productService;
        }

        public static ProductServices GetProductServices()
        {
            return new ProductServiceFixture().GetService();
        }
    }
}
