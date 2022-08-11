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
        private readonly WarehouseDbContext _dbcontext;
        public ProductServices(WarehouseDbContext context)
        {
            _dbcontext = context;
            
        }

        public void AddProduct(Product model)
        {
            _dbcontext.Products.Add(model);
            _dbcontext.SaveChanges();
        }

        public async Task AddProductAsync(Product model)
        {
            await _dbcontext.Products.AddAsync(model);
            await _dbcontext.SaveChangesAsync();
        }

        public Product GetProduct(int id)
        {
            Product product = _dbcontext.Products.Where(prop => prop.Id == id)
                .Include(prop => prop.Company)
                .Include(prop => prop.WarehouseInfo)
                .First();

            product.Store = _dbcontext.Stores.Where(prop => prop.Id == product.Storeid)
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
            return await _dbcontext.Products.Where(prop => prop.Id == id)
                .Include(prop => prop.Company)
                .Include(prop => prop.WarehouseInfo)
                .FirstAsync();

        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbcontext.Products
              .Include(prop => prop.Company)
              .Include(prop => prop.WarehouseInfo)
              .Select(prop => new Product()
              {
                  Id = prop.Id,
                  AgeRestriction = prop.AgeRestriction,
                  CompanyId = prop.CompanyId,
                  Company = new Company()
                  {
                      Id = prop.Company.Id,
                      Name = prop.Company.Name
                  },
                  Description = prop.Description,
                  ImageIurl = prop.ImageIurl,
                  Name = prop.Name,
                  Price = prop.Price,
                  Storeid = prop.Storeid,
                  Store = new Store()
                  {
                      Id = prop.Storeid,
                      address = prop.Store.address,
                      city = prop.Store.city,
                      storeName = prop.Store.storeName
                  },
                  WarehouseInfo = new List<WarehouseInfo>()
              })
              .ToList();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _dbcontext.Products
              .Include(prop => prop.Company)
              .Include(prop => prop.WarehouseInfo)
              .Select(prop => new Product()
              {
                  Id = prop.Id,
                  AgeRestriction = prop.AgeRestriction,
                  CompanyId = prop.CompanyId,
                  Company = new Company()
                  {
                      Id = prop.CompanyId,
                      Name = prop.Company.Name
                  },
                  Description = prop.Description,
                  ImageIurl = prop.ImageIurl,
                  Name = prop.Name,
                  Price = prop.Price,
                  Storeid = prop.Storeid,
                  Store = new Store()
                  {
                      Id = prop.Storeid,
                      address = prop.Store.address,
                      city = prop.Store.city,
                      storeName = prop.Store.storeName
                  },
                  WarehouseInfo = new List<WarehouseInfo>()
              })
              .ToListAsync();
        }

        public void AddProducts(IEnumerable<Product> products)
        {
            try
            {
                _dbcontext.Products.AddRange(products);
                _dbcontext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddProductsAsync(IEnumerable<Product> products)
        {
            await _dbcontext.Products.AddRangeAsync(products);
            await _dbcontext.SaveChangesAsync();
        }

        public void UpdateProduct(Product product)
        {
            _dbcontext.Products.Update(product);
            _dbcontext.SaveChanges();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _dbcontext.Products.Update(product);
            await _dbcontext.SaveChangesAsync();
        }

        public void UpdateProducts(IEnumerable<Product> products)
        {
            _dbcontext.Products.UpdateRange(products);
            _dbcontext.SaveChanges();
        }

        public async void UpdateProductsAsync(IEnumerable<Product> products)
        {
            _dbcontext.Products.UpdateRange(products);
            await _dbcontext.SaveChangesAsync();
        }

        public void DeleteProduct(int id)
        {
            Product item = GetProduct(id);

            _dbcontext.Products.Remove(item);
            _dbcontext.SaveChanges();
        }

        public async Task DeleteProductAsync(int id)
        {
            Product item = await GetProductAsync(id);

            _dbcontext.Products.Remove(item);
            await _dbcontext.SaveChangesAsync();
        }

        public IEnumerable<Product> Search(Func<Product, bool> predicate)
        {
            return _dbcontext.Products.Where(predicate).ToList();
        }

        public async Task<IEnumerable<Product>> SearchAsync(Func<Product, bool> predicate)
        {
            return await (from prod in _dbcontext.Products where predicate(prod) select prod).ToListAsync();
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
                    query = _dbcontext.Products
                       .Include(prop => prop.Company)
                       .Include(prop => prop.WarehouseInfo)
                       .Select(prop => new Product()
                       {
                           Id = prop.Id,
                           AgeRestriction = prop.AgeRestriction,
                           CompanyId = prop.CompanyId,
                           Company = new Company()
                           {
                               Id = prop.CompanyId,
                               Name = prop.Company.Name
                           },
                           Description = prop.Description,
                           ImageIurl = prop.ImageIurl,
                           Name = prop.Name,
                           Price = prop.Price,
                           Storeid = prop.Storeid,
                           Store = new Store()
                           {
                               Id = prop.Storeid,
                               address = prop.Store.address,
                               city = prop.Store.city,
                               storeName = prop.Store.storeName
                           },
                           WarehouseInfo = new List<WarehouseInfo>()
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
