using Microsoft.EntityFrameworkCore;
using WarehouseServices.Contractor;
using WarehouseServices.Services;
using WarehouseModels.Models;
using WarehouseModels.Interfaces;
using WarehouseModels.Validations;
using AutoMapper;
using WarehouseRESTfulAPI.Helpers;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("warehousedb");

//CORS configuration
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options => options.AddPolicy(
    name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.WithOrigins("*")
        .AllowAnyHeader()
        .AllowAnyMethod()
        ;
    }
    ));

// Add services to the container.
builder.Services.AddDbContext<WarehouseCoreLib.DataAccess.WarehouseDbContext>(options =>
            options.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.MigrationsAssembly("WarehouseCoreLib")));

builder.Services.AddAutoMapper(typeof(AutoMapperConfig).Assembly);
WarehouseServices.ServicesInjection.InjectServices(builder.Services);

builder.Services.AddControllers();

var app = builder.Build();

//crea la migracion de base de datos
using var scope = app.Services.CreateScope();
try
{
    var db = scope.ServiceProvider.GetService<WarehouseCoreLib.DataAccess.WarehouseDbContext>();

    if (db.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
        db.Database.Migrate();
}
catch (Exception )
{
    throw;
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }
