using Microsoft.EntityFrameworkCore;
using WarehouseServices.Contractor;
using WarehouseServices.Services;
using WarehouseModels.Models;
using WarehouseModels.Interfaces;
using WarehouseModels.Validations;

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
builder.Services.AddDbContext<WarehouseCoreLib.DataAccess.WarehouseDbContext>(options=>
        options.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.MigrationsAssembly("WarehouseCoreLib")));

// Warehouse Services activation
builder.Services.AddScoped<IWarehouseService<CompaniesServices>, CompaniesServices>();
builder.Services.AddScoped<IWarehouseService<ProductServices>, ProductServices>();
// Validations
builder.Services.AddScoped<IValidation<Company>, CompanyValidations>();
builder.Services.AddScoped<IValidation<Product>, ProductValidations>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }
