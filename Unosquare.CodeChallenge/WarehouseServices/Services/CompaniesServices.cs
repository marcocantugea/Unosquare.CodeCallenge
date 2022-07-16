using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseCoreLib.DataAccess;
using WarehouseCoreLib.Repositories;
using WarehouseModels.Models;
using WarehouseServices.Contractor;
using WarehouseCoreLib.Base;

namespace WarehouseServices.Services
{
    public class CompaniesServices : Service<Company>, IWarehouseService
    {

        public CompaniesServices(WarehouseDbContext context)
        {
            repository = new CompanyRepository();
            repository.dbcontext = context;
        }

        public IEnumerable<Company> getAllCompanies()
        {
            return repository.findAll();
        }

        public Company getCompany(int id)
        {
            return repository.getById(id);
        }
    }
}
