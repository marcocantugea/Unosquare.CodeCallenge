﻿using System;
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
    }
}
