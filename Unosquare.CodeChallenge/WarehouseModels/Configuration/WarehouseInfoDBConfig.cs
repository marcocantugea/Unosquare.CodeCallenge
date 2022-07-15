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
    public class WarehouseInfoDBConfig : IEntityTypeConfiguration<WarehouseInfo>
    {
        public void Configure(EntityTypeBuilder<WarehouseInfo> builder)
        {
            builder.Property(prop => prop.code).IsRequired().HasMaxLength(5);
            builder.Property(prop => prop.name).IsRequired().HasMaxLength(50);

            builder.HasData(populateWarehouse());
        }

        protected List<WarehouseInfo> populateWarehouse()
        {
            List<WarehouseInfo> list = new List<WarehouseInfo>();
            list.Add(new WarehouseInfo() {
                id=1,
                code="MWDC",
                name="Monterrey Warehouse Distrubution Center",
                active=true
            });
            list.Add(new WarehouseInfo()
            {
                id = 2,
                code = "MXDC",
                name = "Mexico Warehouse Distrubution Center",
                active = true
            });
            list.Add(new WarehouseInfo()
            {
                id = 3,
                code = "GDDC",
                name = "Guadalajara Warehouse Distrubution Center",
                active = true
            });

            return list;
        }
    }
}
