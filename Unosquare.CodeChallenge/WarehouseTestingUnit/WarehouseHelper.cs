using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseCoreLib.DataAccess;

namespace Tests
{
    public class WarehouseHelper
    {
        public static WarehouseDbContext dbContext;

        private WarehouseHelper()
        {

        }

        public static WarehouseDbContext createDBContext()
        {
            WarehouseDbContext dbContext = WarehouseHelper.dbContext;
            try
            {
                if (dbContext != null) return WarehouseHelper.dbContext;
                var options = new DbContextOptionsBuilder<WarehouseDbContext>().UseInMemoryDatabase(databaseName: "dev_warehouse").Options;
                WarehouseHelper.dbContext= dbContext = new WarehouseDbContext(options);
                WarehouseHelper.dbContext.Database.EnsureCreated();
                WarehouseHelper.dbContext.Database.Migrate();
                return WarehouseHelper.dbContext;
            }
            catch (Exception)
            {

                return dbContext;
            }


            return dbContext;
        }
    }
}
