using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests;
using WarehouseCoreLib.DataAccess;
using WarehouseModels.Models;
using WarehouseServices.Services;
using WarehouseTestingUnit.Fixtures;
using Xunit;

namespace WarehouseTestingUnit.WarehouseServices
{

    public class WarehouseServices_unitTest :IClassFixture<CompanyServiceFixture>,IClassFixture<ProductServiceFixture>
    {
        private CompanyServiceFixture companyServiceFixture;
        private ProductServiceFixture productServiceFixture;

        public WarehouseServices_unitTest(CompanyServiceFixture companyServiceFixture, ProductServiceFixture productServiceFixture )
        {
            this.companyServiceFixture = companyServiceFixture;
            this.productServiceFixture = productServiceFixture;
        }


        [Fact]
        [Trait("Category", "ServiceCompany")]
        public void GetAllCompanies_GetAllCompaniesItems()
        {
            List<Company> companies = companyServiceFixture.GetService().GetAllCompanies().ToList();

            Assert.NotEmpty(companies);
            Assert.InRange(companies.Count,1,20);
        }

        [Fact]
        [Trait("Category", "ServiceCompany")]
        public async void GetAllCompaniesAsync_GetAllCompaniesItems()
        {
            List<Company> companies = await companyServiceFixture.GetService().GetAllCompaniesAsync();

            Assert.NotEmpty(companies);
            Assert.InRange(companies.Count, 1,100);
        }

        [Fact]
        [Trait("Category", "ServiceCompany")]
        public void GetCompany_GetItemCompanyById()
        {
            Company company = companyServiceFixture.GetService().GetCompany(1);

            Assert.Equal(1, company.Id);

        }

        [Fact]
        [Trait("Category", "ServiceCompany")]
        public async void GetCompanyAsync_GetItemCompanyByID()
        {
            Company company = await companyServiceFixture.GetService().GetCompanyAsync(1);

            Assert.Equal(1, company.Id);
        }

        [Fact]
        [Trait("Category","ServiceCompany")]
        public void AddCompany_AddItemToDb()
        {
            Company newCompany = new Company()
            {
                Name = "new company test unit"
            };

            
            companyServiceFixture.GetService().AddCompany(newCompany);
            Assert.True(true);
        }


        [Fact] 
        [Trait("Category", "ServiceCompany")]
        public async void AddCompanyAsync_AddItemToDb()
        {
            Company newCompany = new Company()
            {
                Name = "new company test unit"
            };

            
            await companyServiceFixture.GetService().AddCompanyAsync(newCompany);
            Assert.True(true);
        }

        [Fact]
        [Trait("Category", "ServiceCompany")]
        public void GetCompanyByName_GetCompanyItem()
        {
            Company newCompany = new Company()
            {
                Name = "company to search"
            };

            companyServiceFixture.GetService().AddCompany(newCompany);

            Company company = companyServiceFixture.GetService().GetCompanyByName("company to search");

            Assert.Equal("company to search", company.Name);
        }

        [Fact]
        [Trait("Category", "ServiceCompany")]
        public async void GetCompanyByNameAsync_GetCompanyItem()
        {
            Company company = await companyServiceFixture.GetService().GetCompanyByNameAsync("Mattel");

            Assert.Equal("Mattel", company.Name);
        }

        [Fact]
        [Trait("Category", "ServiceCompany")]
        public void UpdateCompany_UpdateNameCompany()
        {
            Company newCompany = new Company()
            {
                Name = "new company test unit"
            };
            companyServiceFixture.GetService().AddCompany(newCompany);

            Company company = companyServiceFixture.GetService().GetCompanyByName("new company test unit");
            company.Name = "new company test unit updated";
            companyServiceFixture.GetService().UpdateCompany(company);

            List<Company> listOfCompanies = companyServiceFixture.GetService().GetAllCompanies().ToList();

            Assert.Equal(company.Name,listOfCompanies.Where(item => item.Name == company.Name).First().Name);

        }

        [Fact]
        [Trait("Category", "ServiceCompany")]
        public async void UpdateCompanyAsync_UpdateNameCompany()
        {
            Company company = await companyServiceFixture.GetService().GetCompanyByNameAsync("new company test unit");
            company.Name = "new company test unit updated";
            await companyServiceFixture.GetService().UpdateCompanyAsync(company);

            Assert.True(true);

        }

        [Fact]
        public void DeleteCompany_DeleteCompany()
        {
            Company company = companyServiceFixture.GetService().GetCompanyByName("new company test unit updated");
            companyServiceFixture.GetService().DeleteCompany(company);
            Assert.True(true);
        }

        [Fact]
        [Trait("Category", "ServiceCompany")]
        public async void DeleteCompanyAsync_DeleteCompanyFromDB()
        {
            Company newCompany = new Company()
            {
                Name = "new company test unit to delete"
            };

            await companyServiceFixture.GetService().AddCompanyAsync(newCompany); 
            Company company = await companyServiceFixture.GetService().GetCompanyByNameAsync("new company test unit to delete");
            await companyServiceFixture.GetService().DeleteCompanyAsync(company);

            List<Company> listOfCompanies = await companyServiceFixture.GetService().GetAllCompaniesAsync();

            Assert.Empty(listOfCompanies.Where(item => item.Name == "new company test unit to delete"));
        }

        [Fact]
        [Trait("Category", "ServiceProducts")]
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

            productServiceFixture.GetService().AddProduct(newProduct);

            Assert.True(true);
        }

        [Fact]
        [Trait("Category", "ServiceProducts")]
        public void GetProduct_GetListOfProducts()
        {
            List<Product> products = productServiceFixture.GetService().GetProducts().ToList();

            Assert.InRange(products.Count, 1,100);
        }

        [Fact]
        [Trait("Category", "ServiceProducts")]
        public void GetProductById_GetProductItem()
        {
            List<Product> products = productServiceFixture.GetService().GetProducts().ToList();

            Product product = products.Last();

            Product productFound = productServiceFixture.GetService().GetProduct(product.id);

            Assert.Equal(product.description, productFound.description);
        }

        [Fact]
        [Trait("Category", "ServiceProducts")]
        public void AddProducts_AddSeveralProducts()
        {
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

            productServiceFixture.GetService().AddProducts(newProducts);

            List<Product> products = productServiceFixture.GetService().GetProducts().ToList();
            
            Assert.False(String.IsNullOrEmpty(products.Where(item => item.name == newProduct4.name).First().name));

        }


        [Fact]
        [Trait("Category", "ServiceProducts")]
        public void UpdateProduct_UpdateNameToProduct()
        {
            
            List<Product> products = productServiceFixture.GetService().GetProducts().ToList();

            Product updateProduct = products.Where(item => item.id== 1).First();

            updateProduct.name = "Mercedes Benz a class blue 2022 updated";

            productServiceFixture.GetService().UpdateProduct(updateProduct);

            products = productServiceFixture.GetService().GetProducts().ToList();

            Assert.NotEmpty(products.Where(item=>item.name== "Mercedes Benz a class blue 2022 updated"));

        }

        [Fact]
        [Trait("Category", "ServiceProducts")]
        public void UpdateProducts_UpdateSeveralItems()
        {
            List<Product> products = productServiceFixture.GetService().GetProducts().ToList();
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

            productServiceFixture.GetService().UpdateProducts(updateProducts);


            products = productServiceFixture.GetService().GetProducts().ToList();

            Assert.False(String.IsNullOrEmpty(products.Where(items => items.name == "changed name to item no.1").First().name));
            Assert.False(String.IsNullOrEmpty(products.Where(items => items.name == "changed name to item no.2").First().name));
            Assert.False(String.IsNullOrEmpty(products.Where(items => items.name == "changed name to item no.3").First().name));
            Assert.False(String.IsNullOrEmpty(products.Where(items => items.name == "changed name to item no.4").First().name));
            Assert.False(String.IsNullOrEmpty(products.Where(items => items.name == "changed name to item no.5").First().name));
        }

        [Fact]
        [Trait("Category", "ServiceProducts")]
        public void DeleteProduct_DeleteProduct()
        {

            productServiceFixture.GetService().DeleteProduct(1);
            List<Product> products = productServiceFixture.GetService().GetProducts().ToList();

            products = productServiceFixture.GetService().GetProducts().ToList();

            Assert.Equal(0,products.Where(item => item.id == 1).Count());
        }

        [Fact]
        [Trait("Category", "ServiceProducts")]
        public void SearchProduct_GetAProduct()
        {
            List<Product> products = productServiceFixture.GetService().Search(item => item.ageRestriction == 15).ToList();

            Assert.Equal(4,products.Count);
        }
    }

}
