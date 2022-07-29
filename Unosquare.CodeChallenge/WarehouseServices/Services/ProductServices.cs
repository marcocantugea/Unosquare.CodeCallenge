using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseCoreLib.Base;
using WarehouseCoreLib.DataAccess;
using WarehouseModels.Models;
using WarehouseRepositories.Repositories;
using WarehouseServices.Contractor;

namespace WarehouseServices.Services
{
    public class ProductServices : Service<Product>, IWarehouseService<ProductServices>
    {
        private WarehouseDbContext dbcontext;

        public ProductServices(WarehouseDbContext context)
        {
            dbcontext = context;
            
        }

        public void AddProduct(Product model)
        {
            dbcontext.Products.Add(model);
            dbcontext.SaveChanges();
        }

        public Product GetProduct(int id)
        {
            Product product = dbcontext.Products.Where(prop => prop.id == id)
                .Include(prop => prop.company)
                .Include(prop => prop.warehouseInfo)
                .First();

            product.store = dbcontext.Stores.Where(prop => prop.Id == product.storeid)
                .Select(prop => new Store()
                {
                    Id = prop.Id,
                    storeName = prop.storeName,
                    address = prop.address,
                    city = prop.city,
                    products = new List<Product>()
                })
                .First();



            return product;
        }

        public IEnumerable<Product> GetProducts()
        {
            return dbcontext.Products
              .Include(prop => prop.company)
              .Include(prop => prop.warehouseInfo)
              .Select(prop => new Product()
              {
                  id = prop.id,
                  ageRestriction = prop.ageRestriction,
                  companyId = prop.companyId,
                  company = new Company()
                  {
                      Id = prop.companyId,
                      Name = prop.company.Name
                  },
                  description = prop.description,
                  imageIurl = prop.imageIurl,
                  name = prop.name,
                  price = prop.price,
                  storeid = prop.storeid,
                  store = new Store()
                  {
                      Id = prop.storeid,
                      address = prop.store.address,
                      city = prop.store.city,
                      storeName = prop.store.storeName
                  },
                  warehouseInfo = new List<WarehouseInfo>()
              })
              .ToList();
        }

        public void AddProducts(IEnumerable<Product> products)
        {
            try
            {
                dbcontext.Products.AddRange(products);
                dbcontext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateProduct(Product product)
        {
            dbcontext.Products.Update(product);
            dbcontext.SaveChanges();
        }

        public void UpdateProducts(IEnumerable<Product> products)
        {
            dbcontext.Products.UpdateRange(products);
            dbcontext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            Product item = GetProduct(id);

            dbcontext.Products.Remove(item);
            dbcontext.SaveChanges();
        }

        public IEnumerable<Product> Search(Func<Product, bool> predicate)
        {
            return dbcontext.Products.Where(predicate).ToList();
        }

        public IEnumerable<Product> Search(IEnumerable<Func<Product, bool>> filters)
        {
            if (filters.Count() <= 0) return new List<Product>();

            IEnumerable<Product> query = new List<Product>();

            int index = 0;
            foreach (var filter in filters)
            {
                if (index == 0)
                {
                    query = dbcontext.Products
                       .Include(prop => prop.company)
                       .Include(prop => prop.warehouseInfo)
                       .Select(prop => new Product()
                       {
                           id = prop.id,
                           ageRestriction = prop.ageRestriction,
                           companyId = prop.companyId,
                           company = new Company()
                           {
                               Id = prop.companyId,
                               Name = prop.company.Name
                           },
                           description = prop.description,
                           imageIurl = prop.imageIurl,
                           name = prop.name,
                           price = prop.price,
                           storeid = prop.storeid,
                           store = new Store()
                           {
                               Id = prop.storeid,
                               address = prop.store.address,
                               city = prop.store.city,
                               storeName = prop.store.storeName
                           },
                           warehouseInfo = new List<WarehouseInfo>()
                       })
                       .Where(filter);
                    continue;
                }
                query = query.Where(filter);
                index++;
            }


            return query;

        }
    }
}
