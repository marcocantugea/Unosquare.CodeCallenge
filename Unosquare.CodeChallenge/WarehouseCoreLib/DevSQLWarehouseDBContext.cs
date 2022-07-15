using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseCoreLib.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
namespace WarehouseCoreLib
{
    public class DevSQLWarehouseDBContext : WarehouseDbContext
    {
        protected readonly string devconnection = @"Server=.\SQLEXPRESS;Database=dev_warehouse;Trusted_Connection=True;MultipleActiveResultSets=true;";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlServer(devconnection);
    }
}
