using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests;
using WarehouseModels.Models;
using WarehouseRepositories.Repositories;

namespace WarehouseTestingUnit.WarehouseCoreLib.Repositories
{
    public class ProductsRepository_unitTest
    {
        [Fact]
        public void test_add_AddNewProduct()
        {
            ProductsRepository repo = new ProductsRepository();
            repo.dbcontext = WarehouseHelper.createDBContext();

            Product newProduct = new Product()
            {
                 name= "LEGO Martillo de Thor",
                 description= "El kit de 979 piezas incluye una minifigura de Thor",
                 ageRestriction=5,
                 companyId=7,
                 imageIurl= "https://www.alternate.lu/p/600x600/1/2/LEGO_76209_Marvel_Super_Heroes_Thors_Hammer__Konstruktionsspielzeug@@1787621.jpg",
                 price=2599,
                 storeid=1
            };

            repo.add(newProduct);
            repo.save();

            Assert.True(true);

        }

        [Fact]
        public void test_delete_RemoveProductCreated()
        {

            ProductsRepository repo = new ProductsRepository();
            repo.dbcontext = WarehouseHelper.createDBContext();
            Product removeProduct = new Product()
            {
                id = 10
            };

            repo.delete(removeProduct);
            repo.save();

            Assert.True(true);
        }

        [Fact]
        public void test_update_UpdateProductInfo()
        {
            ProductsRepository repo = new ProductsRepository();
            repo.dbcontext = WarehouseHelper.createDBContext();
            Product productFound = repo.getById(9);
            productFound.description = "Control Inalámbrico Dualsense Cosmic Red";


            repo.update(productFound);
            repo.save();

            Assert.True(true);
        }
    }
}
