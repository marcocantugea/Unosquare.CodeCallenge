using Microsoft.EntityFrameworkCore;
using WarehouseServices.Contractor;
using WarehouseServices.Services;
using WarehouseCoreLib.Interfaces;
using WarehouseModels.Models;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("warehousedb");

// Add services to the container.
builder.Services.AddDbContext<WarehouseCoreLib.DataAccess.WarehouseDbContext>(options=>
        options.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.MigrationsAssembly("WarehouseCoreLib")));
builder.Services.AddScoped<IWarehouseService, CompaniesServices>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
