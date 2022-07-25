using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseCoreLib.Base;
using WarehouseModels.Interfaces;
using WarehouseModels.Models;

namespace WarehouseRepositories.Repositories
{
    public class ProductsRepository : Repository<Product>
    {
        public Product getPoduct(int id)
        {
            Product product=  dbcontext.Products.Where(prop => prop.id == id)
                .Include(prop => prop.company)
                .Include(prop=> prop.warehouseInfo)
                .First();

            product.store= dbcontext.Stores.Where(prop => prop.Id == product.storeid)
                .Select(prop => new Store(){ 
                    Id= prop.Id, 
                    storeName=prop.storeName, 
                    address= prop.address, 
                    city= prop.city,
                    products =new List<Product>()
                })
                .First();



            return product;
        }

        public IEnumerable<Product> getProducts()
        {
            return dbcontext.Products
               .Include(prop => prop.company)
               .Include(prop => prop.warehouseInfo)
               .Select(prop => new Product()
               {
                    id= prop.id,
                    ageRestriction = prop.ageRestriction,
                    companyId=prop.companyId,
                    company= new Company()
                    {
                         Id=prop.companyId,
                         Name=prop.company.Name
                    },
                    description=prop.description,
                    imageIurl=prop.imageIurl,
                    name=prop.name,
                    price=prop.price,
                    storeid=prop.storeid,
                    store= new Store()
                    {
                        Id=prop.storeid,
                        address=prop.store.address,
                        city=prop.store.city,
                        storeName=prop.store.storeName
                    },
                    warehouseInfo= new List<WarehouseInfo>()
               })
               .ToList();
        }

        public void addProducts(IEnumerable<Product> products)
        {
            dbcontext.Products.AddRange(products);
        }

        public void updateProducts(IEnumerable<Product> products)
        {
            dbcontext.Products.UpdateRange(products);
            save();
        }

        public IEnumerable<Product> Search(Func<Product,bool> predicate)
        {
            return dbcontext.Products.Where(predicate).ToList();
        }

        public void deleteProduct(int id)
        {
            dbcontext.Products.Remove(getById(id));
        }

        public IEnumerable<Product> Search(IEnumerable<Func<Product, bool>> filters)
        {
            if (filters.Count() <= 0) return new List<Product>();

            IEnumerable<Product> query = new List<Product>();

            int index = 0;
            foreach (var filter in filters)
            {
                if (index == 0) {
                    query=dbcontext.Products
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
                } 
                query = query.Where(filter);
                index++;
            }


            return query;

        }
    }
}
