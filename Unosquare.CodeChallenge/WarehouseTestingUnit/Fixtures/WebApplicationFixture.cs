using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseCoreLib.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.TestHost;

namespace WarehouseTestingUnit.Fixtures
{
    public class WebApplicationFixture
    {
        private readonly WebApplicationFactory<Program> _webApplicationFactory;

        public WebApplicationFixture()
        {
            _webApplicationFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services => {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<WarehouseDbContext>));
                    services.Remove(descriptor);
                    services.AddDbContext<WarehouseDbContext>(options => {
                        options.UseInMemoryDatabase(databaseName: "dev_warehouseMem"); 
                    });

                    var sp = services.BuildServiceProvider();

                    using(var scope = sp.CreateScope())
                    {
                        var scopedSerivces = scope.ServiceProvider;
                        var db = scopedSerivces.GetRequiredService<WarehouseDbContext>();
                        db.Database.EnsureCreated();
                    }

                });
            });
        }

        public WebApplicationFactory<Program> GetWebApplicationFactory()
        {
            return _webApplicationFactory;
        }
    }
}
