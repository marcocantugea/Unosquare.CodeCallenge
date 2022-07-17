using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseCoreLib.DataAccess;
using WarehouseModels.Models;
using WarehouseServices.Contractor;
using WarehouseCoreLib.Base;
using WarehouseRepositories.Repositories;

namespace WarehouseServices.Services
{
    public class CompaniesServices : Service<Company>, IWarehouseService
    {
        private CompanyRepository repository;

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

        public void addCompany(Company company)
        {
            repository.add(company);
            repository.save();
        }

        public void deleteCompany(Company company)
        {
            repository.delete(company);
            repository.save();
        }

        public Company getCompanyByName(string name)
        {
            return repository.getCompanyByName(name);
        }

        public void updateCompany(Company company)
        {
            repository.update(company);
            repository.save();
        }
    }
}
