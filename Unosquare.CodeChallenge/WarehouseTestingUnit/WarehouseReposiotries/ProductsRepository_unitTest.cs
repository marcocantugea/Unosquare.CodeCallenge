using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests;
using WarehouseModels.Models;
using WarehouseRepositories.Repositories;
using WarehouseRESTfulAPI.RequestModels;
using WarehouseModels.Interfaces;
using System.Linq.Expressions;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

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

            NUnit.Framework.Assert.IsNotEmpty(productos);
        }

        [Fact]
        public void test_getProductByFilters_filterByName()
        {
            ProductsRepository repo = new ProductsRepository();
            repo.dbcontext = WarehouseHelper.createDBContext();
            List<Func<IProduct, bool>> filters = new List<Func<IProduct, bool>>();

            filters.Add(prod => prod.name.ToLower().Contains("world"));

            List<Product> productsFound = repo.Search(filters).ToList();

            Assert.NotEmpty(productsFound);
            Assert.Equal("Jurassic World Dominion Extreme Damage", productsFound[0].name);

        }

        [Fact]
        public void test_getProductByFilters_filterByNameWords()
        {
            ProductsRepository repo = new ProductsRepository();
            repo.dbcontext = WarehouseHelper.createDBContext();
            List<Func<IProduct, bool>> filters = new List<Func<IProduct, bool>>();

            filters.Add(prod => prod.name.ToLower().Contains("marvel"));
            filters.Add(prod => prod.name.ToLower().Contains("iron"));

            List<Product> productsFound = repo.Search(filters).ToList();

            Assert.NotEmpty(productsFound);
            Assert.Equal("Iron Man Mark 3 Mark III Figura de acción marvel", productsFound[0].name);

        }


        [Fact]
        public void test_getProductByFilters_filterByNameAndDescriptionSeveralRecors()
        {
            ProductsRepository repo = new ProductsRepository();
            repo.dbcontext = WarehouseHelper.createDBContext();
            List<Func<IProduct, bool>> filters = new List<Func<IProduct, bool>>();

            filters.Add(prod => prod.name.ToLower().Contains("marvel"));
            filters.Add(prod => prod.description.ToLower().Contains("symbiote"));

            List<Product> productsFound = repo.Search(filters).ToList();

            Assert.NotEmpty(productsFound);
            Assert.Equal(1, productsFound.Count());
            Assert.Equal("Spiderman Symbiote Marvel Legends marvel", productsFound[0].name);

        }

        [Fact]
        public void test_getProductByFilters_filterByNameAndMaxAge()
        {
            ProductsRepository repo = new ProductsRepository();
            repo.dbcontext = WarehouseHelper.createDBContext();
            List<Func<IProduct, bool>> filters = new List<Func<IProduct, bool>>();

            filters.Add(prod => prod.name.ToLower().Contains("marvel"));
            filters.Add(prod => prod.ageRestriction<15);

            List<Product> productsFound = repo.Search(filters).ToList();

            Assert.NotEmpty(productsFound);
            Assert.Equal(2, productsFound.Count());
            //Assert.Equal("Spiderman Symbiote Marvel Legends marvel", productsFound[0].name);

        }

        [Fact]
        public void test_getProductByFilters_filterByNameAndMaxAgePrice()
        {
            ProductsRepository repo = new ProductsRepository();
            repo.dbcontext = WarehouseHelper.createDBContext();
            List<Func<IProduct, bool>> filters = new List<Func<IProduct, bool>>();

            filters.Add(prod => prod.name.ToLower().Contains("marvel"));
            filters.Add(prod => prod.ageRestriction < 15);
            filters.Add(prod => prod.price>700);

            List<Product> productsFound = repo.Search(filters).ToList();

            Assert.Empty(productsFound);
            Assert.Equal(0, productsFound.Count());
            //Assert.Equal("Spiderman Symbiote Marvel Legends marvel", productsFound[0].name);

        }
        
    }

}
