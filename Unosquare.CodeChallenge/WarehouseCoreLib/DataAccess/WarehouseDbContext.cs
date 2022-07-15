using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WarehouseModels.Configuration;
using WarehouseModels.Interfaces;
using WarehouseModels.Models;

namespace WarehouseCoreLib.DataAccess
{
    public class WarehouseDbContext : DbContext 
    {
        public WarehouseDbContext() : base()
        {

        }

        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options)
        {
        }

        public static WarehouseDbContext GetWarehouseDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new WarehouseDbContext(optionsBuilder.Options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyDBConfig());
            modelBuilder.ApplyConfiguration(new ProductsDBConfig());
            modelBuilder.ApplyConfiguration(new WarehouseInfoDBConfig());
            modelBuilder.ApplyConfiguration(new StoreDBConfig());
            modelBuilder.ApplyConfiguration(new ProductWarehouseDBConfig());
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<WarehouseInfo> WarehouseInfo { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ProductWarehouse> ProductsWarehouses { get; set; }
    }
}
