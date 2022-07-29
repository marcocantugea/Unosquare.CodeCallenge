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
    public class StoreDBConfig : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.Property(prop => prop.storeName).IsRequired().HasMaxLength(50);
            builder.Property(prop => prop.address).IsRequired().HasMaxLength(100);
            builder.Property(prop => prop.city).IsRequired().HasMaxLength(60);
            builder.HasData(PopulateStores());
        }

        protected List<Store> PopulateStores()
        {
            List<Store> stores = new List<Store>();
            stores.Add(new Store() { Id=1, storeName="Galerias Monterrey", address= "Plaza Galerias,Avenida Insurgentes 2500, Galerias Monterrey, Monterrey", city="Monterrey, NL" });
            stores.Add(new Store() { Id = 2, storeName = "Periplaza", address = "9 sur 11302,Sobre Periférico Ecológico", city = "Puebla, Puebla" });
            stores.Add(new Store() { Id = 3, storeName = "Galerias Puerto Vallarta", address = "Avenida Francisco Medina Ascencio 2920, Puerto Vallarta", city = "Puerto Vallarta, Jal." });
            stores.Add(new Store() { Id = 4, storeName = "Plaza Periferico", address = "Libramiento Monterrey", city = "Reynosa, Tamaulipas" });
            stores.Add(new Store() { Id = 5, storeName = "Plaza Cristal", address = "Avenida Lázaro Cárdenas Sn", city = "Xalapa, Veracruz" });

            return stores;
        }
    }
}
