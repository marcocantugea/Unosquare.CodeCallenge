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
        private ProductsRepository repository;

        public ProductServices(WarehouseDbContext context)
        {
            repository = new ProductsRepository();
            repository.dbcontext = context;
        }

        public void addProduct(Product model)
        {
            repository.add(model);
            repository.save();
        }

        public Product getProduct(int id)
        {
            return repository.getPoduct(id);
        }

        public IEnumerable<Product> getProducts()
        {
            return repository.getProducts();
        }

        public void addProducts(IEnumerable<Product> products)
        {
            try
            {
                repository.addProducts(products);
                repository.save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void updateProduct(Product product)
        {
            repository.update(product);
            repository.save();
        }

        public void updateProducts(IEnumerable<Product> products)
        {
            repository.updateProducts(products);
        }

        public void deleteProduct(int id)
        {
            repository.deleteProduct(id);
            repository.save();
        }
    }
}
