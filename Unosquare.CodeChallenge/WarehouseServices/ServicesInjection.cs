using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Interfaces;
using WarehouseModels.Models;
using WarehouseModels.Validations;
using WarehouseServices.Contractor;
using WarehouseServices.Services;

namespace WarehouseServices
{
    public static class ServicesInjection
    {

        public static IServiceCollection InjectServices(IServiceCollection services)
        {
            // Warehouse Services activation
            services.AddScoped<IWarehouseService<CompaniesServices>, CompaniesServices>();
            services.AddScoped<IWarehouseService<ProductServices>, ProductServices>();
            // Validations
            services.AddScoped<IValidation<Company>, CompanyValidations>();
            services.AddScoped<IValidation<Product>, ProductValidations>();

            return services;
        }

    }
}
