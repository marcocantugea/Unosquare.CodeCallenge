using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Tests;
using WarehouseCoreLib.DataAccess;
using WarehouseModels.Models;
using WarehouseServices.Services;
using WarehouseHelper = Tests.WarehouseHelper;
using Assert = NUnit.Framework.Assert;
//using Theory = NUnit.Framework.TheoryAttribute;
//using TestFixture = NUnit.Framework.TestFixtureAttribute;
using NUnit.Framework;

namespace WarehouseTestingUnit.WarehouseServices
{

    public class WarehouseServices_unitTest
    {
        private WarehouseDbContext dbContext;

        public WarehouseServices_unitTest()
        {
            dbContext = WarehouseHelper.createDBContext();
        }


        [Fact]
        public void GetAllCompanies_GetAllCompaniesItems()
        {
            CompaniesServices service = new CompaniesServices(dbContext);
            List<Company> companies = service.GetAllCompanies().ToList();

            Assert.IsNotEmpty(companies);
            Assert.Greater(companies.Count, 0);
        }

        [Fact]
        public async void GetAllCompaniesAsync_GetAllCompaniesItems()
        {
            CompaniesServices service = new CompaniesServices(dbContext);
            List<Company> companies = await  service.GetAllCompaniesAsync();

            Assert.IsNotEmpty(companies);
            Assert.Greater(companies.Count, 0);
        }

        [Fact]
        public void GetCompany_GetItemCompanyById()
        {
            CompaniesServices service = new CompaniesServices(dbContext);
            Company company = service.GetCompany(1);

            Assert.AreEqual(1, company.Id);

        }

        [Fact]
        public async void GetCompanyAsync_GetItemCompanyByID()
        {
            CompaniesServices service = new CompaniesServices(dbContext);
            Company company = await service.GetCompanyAsync(1);

            Assert.AreEqual(1, company.Id);
        }

        [Fact]
        public void AddCompany_AddItemToDb()
        {
            Company newCompany = new Company()
            {
                Name = "new company test unit"
            };

            CompaniesServices service = new CompaniesServices(dbContext);
            service.AddCompany(newCompany);
            Assert.True(true);
        }


        [Fact]
        public async void AddCompanyAsync_AddItemToDb()
        {
            Company newCompany = new Company()
            {
                Name = "new company test unit"
            };

            CompaniesServices service = new CompaniesServices(dbContext);
            await service.AddCompanyAsync(newCompany);
            Assert.True(true);
        }

        [Fact]
        public void GetCompanyByName_GetCompanyItem()
        {
            Company newCompany = new Company()
            {
                Name = "company to search"
            };

            CompaniesServices service = new CompaniesServices(dbContext);
            service.AddCompany(newCompany);

            Company company = service.GetCompanyByName("company to search");

            Assert.AreEqual("company to search", company.Name);
        }

        [Fact]
        public async void GetCompanyByNameAsync_GetCompanyItem()
        {
            CompaniesServices service = new CompaniesServices(dbContext);
            Company company = await service.GetCompanyByNameAsync("Mattel");

            Assert.AreEqual("Mattel", company.Name);
        }

        [Fact]
        public void UpdateCompany_UpdateNameCompany()
        {
            CompaniesServices service = new CompaniesServices(dbContext);

            Company newCompany = new Company()
            {
                Name = "new company test unit"
            };
            service.AddCompany(newCompany);

            Company company = service.GetCompanyByName("new company test unit");
            company.Name = "new company test unit updated";
            service.UpdateCompany(company);

            List<Company> listOfCompanies = service.GetAllCompanies().ToList();

            Assert.AreEqual(company.Name,listOfCompanies.Where(item => item.Name == company.Name).First().Name);

        }

        [Fact]
        public async void UpdateCompanyAsync_UpdateNameCompany()
        {
            CompaniesServices service = new CompaniesServices(dbContext);
            Company company = await service.GetCompanyByNameAsync("new company test unit");
            company.Name = "new company test unit updated";
            await service.UpdateCompanyAsync(company);

            Assert.IsTrue(true);

        }

        [Fact]
        public void DeleteCompany_DeleteCompany()
        {
            CompaniesServices service = new CompaniesServices(dbContext);
            Company company = service.GetCompanyByName("new company test unit updated");
            service.DeleteCompany(company);
            Assert.IsTrue(true);
        }

        [Fact]
        public async void DeleteCompanyAsync_DeleteCompanyFromDB()
        {
            Company newCompany = new Company()
            {
                Name = "new company test unit to delete"
            };

            CompaniesServices service = new CompaniesServices(dbContext);
            await service.AddCompanyAsync(newCompany); 
            Company company = await service.GetCompanyByNameAsync("new company test unit to delete");
            await service.DeleteCompanyAsync(company);

            List<Company> listOfCompanies = await service.GetAllCompaniesAsync();

            Assert.IsEmpty(listOfCompanies.Where(item => item.Name == "new company test unit to delete"));
        }

        [Fact]
        public void AddProduct_AddNewProduct()
        {
            Product newProduct = new Product()
            {
                name = " Mercedes Benz A Class Blue 2022",
                description = "Hot Wheels Toys 19 Mercedes Benz A Class Blue 2022",
                ageRestriction = 5,
                companyId = 2,
                imageIurl = "https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQNELVMHT8Ofj_NCZdtCFIYb8ja76slVkRgXNHwUsrD6IWDYQSTG2UNDajeYnfXZlQjhKSC0vBZjf0h1yk7yoBk73H-0T3l7z-trZg2NCs&usqp=CAE",
                price = 221.50m,
                storeid = 1
            };

            ProductServices service = new ProductServices(dbContext);
            service.AddProduct(newProduct);

            Assert.IsTrue(true);
        }

        [Fact]
        public void GetProduct_GetListOfProducts()
        {
            ProductServices service = new ProductServices(dbContext);
            List<Product> products = service.GetProducts().ToList();

            Assert.Greater(products.Count, 1);
        }

        [Fact]
        public void GetProductById_GetProductItem()
        {
            ProductServices service = new ProductServices(dbContext);
            List<Product> products = service.GetProducts().ToList();

            Product product = products.Last();

            Product productFound = service.GetProduct(product.id);

            Assert.AreEqual(product.description, productFound.description);
        }

        [Fact]
        public void AddProducts_AddSeveralProducts()
        {
            ProductServices service = new ProductServices(dbContext);
            List<Product> newProducts = new List<Product>();

            Product newProduct1 = new Product()
            {
                name = "Toy test 1",
                description = "Toy test 1",
                ageRestriction = 1,
                companyId = 2,
                imageIurl = "",
                price = 1.50m,
                storeid = 1
            };
            Product newProduct2 = new Product()
            {
                name = "Toy test 2",
                description = "Toy test 2",
                ageRestriction = 1,
                companyId = 2,
                imageIurl = "",
                price = 1.50m,
                storeid = 1
            };
            Product newProduct3 = new Product()
            {
                name = "Toy test 3",
                description = "Toy test 3",
                ageRestriction = 1,
                companyId = 2,
                imageIurl = "",
                price = 1.50m,
                storeid = 1
            };

            Product newProduct4 = new Product()
            {
                name = "Toy test 4",
                description = "Toy test 4",
                ageRestriction = 1,
                companyId = 2,
                imageIurl = "",
                price = 1.50m,
                storeid = 1
            };

            newProducts.Add(newProduct1);
            newProducts.Add(newProduct2);
            newProducts.Add(newProduct3);
            newProducts.Add(newProduct4);

            service.AddProducts(newProducts);

            List<Product> products = service.GetProducts().ToList();
            
            Assert.IsFalse(String.IsNullOrEmpty(products.Where(item => item.name == newProduct4.name).First().name));

        }


        [Fact]
        public void UpdateProduct_UpdateNameToProduct()
        {
            ProductServices service = new ProductServices(dbContext);

            List<Product> products = service.GetProducts().ToList();

            Product updateProduct = products.Where(item => item.id== 1).First();

            updateProduct.name = "Mercedes Benz a class blue 2022 updated";
            
            service.UpdateProduct(updateProduct);

            products = service.GetProducts().ToList();

            Assert.IsNotEmpty(products.Where(item=>item.name== "Mercedes Benz a class blue 2022 updated"));

        }

        [Fact]
        public void UpdateProducts_UpdateSeveralItems()
        {
            ProductServices service = new ProductServices(dbContext);
            List<Product> products = service.GetProducts().ToList();
            products.Reverse();
            Product product1 = products[0];
            Product product2 = products[1];
            Product product3 = products[3];
            Product product4 = products[4];
            Product product5 = products[5];

            List<Product> updateProducts = new List<Product>();
            updateProducts.Add(product1);
            updateProducts.Add(product2);
            updateProducts.Add(product3);
            updateProducts.Add(product4);
            updateProducts.Add(product5);

            int index = 1;
            foreach (Product product in updateProducts)
            {
                product.name = "changed name to item no." + index;
                product.company = null;
                product.store = null;
                index++;
            }

            service.UpdateProducts(updateProducts);


            products = service.GetProducts().ToList();

            Assert.IsFalse(String.IsNullOrEmpty(products.Where(items => items.name == "changed name to item no.1").First().name));
            Assert.IsFalse(String.IsNullOrEmpty(products.Where(items => items.name == "changed name to item no.2").First().name));
            Assert.IsFalse(String.IsNullOrEmpty(products.Where(items => items.name == "changed name to item no.3").First().name));
            Assert.IsFalse(String.IsNullOrEmpty(products.Where(items => items.name == "changed name to item no.4").First().name));
            Assert.IsFalse(String.IsNullOrEmpty(products.Where(items => items.name == "changed name to item no.5").First().name));
        }

        [Fact]
        [Test]
        public void DeleteProduct_DeleteProduct()
        {
            ProductServices service = new ProductServices(dbContext);
           
            
            service.DeleteProduct(1);
            List<Product> products = service.GetProducts().ToList();

            products = service.GetProducts().ToList();

            Assert.AreEqual(0,products.Where(item => item.id == 1).Count());
        }

        [Fact]
        public void SearchProduct_GetAProduct()
        {
            ProductServices service = new ProductServices(dbContext);
            List<Product> products = service.Search(item => item.ageRestriction == 15).ToList();

            Assert.AreEqual(4,products.Count);
        }
    }

}
