using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseCoreLib.DataAccess;

namespace WarehouseTestingUnit.Fixtures
{
    public class WarehouseDbContextFixture
    {
        private readonly WarehouseDbContext _dbContext;

        public WarehouseDbContextFixture()
        {
            var options = new DbContextOptionsBuilder<WarehouseDbContext>().UseInMemoryDatabase(databaseName: "dev_warehouse").Options;
            _dbContext = new WarehouseDbContext(options);
            _dbContext.Database.EnsureCreated();
            //_dbContext.Database.Migrate();
        }

        public WarehouseDbContext GetDbContext()
        {
            return _dbContext;
        }
    }
}
