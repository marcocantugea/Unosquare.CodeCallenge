using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseCoreLib.DataAccess;
using WarehouseModels.Models;
using WarehouseServices.Contractor;
using Microsoft.EntityFrameworkCore;

namespace WarehouseServices.Services
{
    public class CompaniesServices : IWarehouseService<CompaniesServices>
    {
        private readonly WarehouseDbContext _dbcontext;
        public CompaniesServices(WarehouseDbContext context)
        {
            _dbcontext = context;
        }

        public IEnumerable<Company> GetAllCompanies(int limit = 0)
        {

            if (limit == 0) return _dbcontext.Companies;
            return _dbcontext.Companies.Take(limit);
        }

        public async Task<List<Company>> GetAllCompaniesAsync(int limit = 0)
        {
            return await _dbcontext.Companies.ToListAsync();
        }

        public Company GetCompany(int id)
        {
            return _dbcontext.Companies.Find(id);
        }

        public async Task<Company> GetCompanyAsync(int id)
        {
            return  await _dbcontext.Companies.FindAsync(id);
        }

        public void AddCompany(Company company)
        {
            _dbcontext.Companies.Add(company);
            _dbcontext.SaveChanges();
        }

        public async Task AddCompanyAsync(Company company)
        {
            await _dbcontext.Companies.AddAsync(company);
            await _dbcontext.SaveChangesAsync();
        }

        public void DeleteCompany(Company company)
        {
            _dbcontext.Companies.Remove(company);
            _dbcontext.SaveChanges();
        }

        public async Task DeleteCompanyAsync(Company company)
        {
            _dbcontext.Companies.Remove(company);
            await _dbcontext.SaveChangesAsync();
        }

        public Company GetCompanyByName(string name)
        {
            return _dbcontext.Companies.Where(company => company.Name == name).First();
        }

        public async Task<Company> GetCompanyByNameAsync(string name)
        {
            return await _dbcontext.Companies.Where(company => company.Name == name).FirstAsync();
        }

        public void UpdateCompany(Company company)
        {
            _dbcontext.Companies.Update(company);
            _dbcontext.SaveChanges();
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            _dbcontext.Companies.Update(company);
            await _dbcontext.SaveChangesAsync();
            
        }
    }
}
