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
        public static WarehouseDbContext createDBContext()
        {
            WarehouseDbContext dbContext = null;
            try
            {
                string connectionString = ConfigurationAppSettings.Configuration().ConnectionStrings.ConnectionStrings["dev_warehouse"].ConnectionString ?? "";
                dbContext = WarehouseDbContext.GetWarehouseDbContext(connectionString);
            }
            catch (Exception)
            {

                return dbContext;
            }


            return dbContext;
        }
    }
}
