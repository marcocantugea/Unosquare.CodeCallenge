using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseCoreLib.DataAccess;
using WarehouseModels.Models;
using WarehouseServices.Contractor;

namespace WarehouseServices.Services
{
    public class ProductServices :  IWarehouseService<ProductServices>
    {
        private readonly WarehouseDbContext dbcontext;
        public ProductServices(WarehouseDbContext context)
        {
            dbcontext = context;
            
        }

        public void AddProduct(Product model)
        {
            dbcontext.Products.Add(model);
            dbcontext.SaveChanges();
        }

        public async Task AddProductAsync(Product model)
        {
            await dbcontext.Products.AddAsync(model);
            await dbcontext.SaveChangesAsync();
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

        public  async Task<Product> GetProductAsync(int id)
        {
            return await dbcontext.Products.Where(prop => prop.id == id)
                .Include(prop => prop.company)
                .Include(prop => prop.warehouseInfo)
                .FirstAsync();

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
                      id = prop.company.id,
                      name = prop.company.name
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

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await dbcontext.Products
              .Include(prop => prop.company)
              .Include(prop => prop.warehouseInfo)
              .Select(prop => new Product()
              {
                  id = prop.id,
                  ageRestriction = prop.ageRestriction,
                  companyId = prop.companyId,
                  company = new Company()
                  {
                      id = prop.companyId,
                      name = prop.company.name
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
              .ToListAsync();
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

        public async Task AddProductsAsync(IEnumerable<Product> products)
        {
            await dbcontext.Products.AddRangeAsync(products);
            await dbcontext.SaveChangesAsync();
        }

        public void UpdateProduct(Product product)
        {
            dbcontext.Products.Update(product);
            dbcontext.SaveChanges();
        }

        public async Task UpdateProductAsync(Product product)
        {
            dbcontext.Products.Update(product);
            await dbcontext.SaveChangesAsync();
        }

        public void UpdateProducts(IEnumerable<Product> products)
        {
            dbcontext.Products.UpdateRange(products);
            dbcontext.SaveChanges();
        }

        public async void UpdateProductsAsync(IEnumerable<Product> products)
        {
            dbcontext.Products.UpdateRange(products);
            await dbcontext.SaveChangesAsync();
        }

        public void DeleteProduct(int id)
        {
            Product item = GetProduct(id);

            dbcontext.Products.Remove(item);
            dbcontext.SaveChanges();
        }

        public async Task DeleteProductAsync(int id)
        {
            Product item = await GetProductAsync(id);

            dbcontext.Products.Remove(item);
            await dbcontext.SaveChangesAsync();
        }

        public IEnumerable<Product> Search(Func<Product, bool> predicate)
        {
            return dbcontext.Products.Where(predicate).ToList();
        }

        public async Task<IEnumerable<Product>> SearchAsync(Func<Product, bool> predicate)
        {
            return await (from prod in dbcontext.Products where predicate(prod) select prod).ToListAsync();
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
                               id = prop.companyId,
                               name = prop.company.name
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
