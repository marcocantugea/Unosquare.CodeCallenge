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
    public class ProductsRepository_unitTest
    {

        [Fact]
        public void test_getProducts_getListOfProducts()
        {
            ProductsRepository repo = new ProductsRepository();
            repo.dbcontext = WarehouseHelper.createDBContext();
            List<Product> productos = repo.getProducts().ToList();

            Assert.NotEmpty(productos);
        }
    }
}
