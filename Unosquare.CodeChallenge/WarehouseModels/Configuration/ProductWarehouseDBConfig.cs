using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Models;

namespace WarehouseModels.Configuration
{
    public class ProductWarehouseDBConfig : IEntityTypeConfiguration<ProductWarehouse>
    {
        public void Configure(EntityTypeBuilder<ProductWarehouse> builder)
        {
            builder.HasKey(prop => new { prop.productId, prop.warehouseId });
            builder.HasData(PopulateStock());
        }

        protected List<ProductWarehouse> PopulateStock()
        {
            List<ProductWarehouse> list = new List<ProductWarehouse>();

            for (int i = 0; i < 13; i++)
            {
                int warehouseid = (new Random()).Next(1, 3);
                int stock = (new Random()).Next(0, 50);
                list.Add(new ProductWarehouse()
                {
                    productId = i,
                    warehouseId = warehouseid,
                    stock = stock
                });
            }
            return list;
        }

    }
}
