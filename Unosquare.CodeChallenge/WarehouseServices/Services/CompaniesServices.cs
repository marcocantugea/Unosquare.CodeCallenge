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
        private readonly WarehouseDbContext dbcontext;

        public CompaniesServices(WarehouseDbContext context)
        {
            dbcontext = context;
        }

        public IEnumerable<Company> GetAllCompanies(int limit = 0)
        {

            if (limit == 0) return dbcontext.Companies;
            return dbcontext.Companies.Take(limit);
        }

        public async Task<List<Company>> GetAllCompaniesAsync(int limit = 0)
        {
            return await dbcontext.Companies.ToListAsync();
        }

        public Company GetCompany(int id)
        {
            return dbcontext.Companies.Find(id);
        }

        public async Task<Company> GetCompanyAsync(int id)
        {
            return  await dbcontext.Companies.FindAsync(id);
        }

        public void AddCompany(Company company)
        {
            dbcontext.Companies.Add(company);
            dbcontext.SaveChanges();
        }

        public async Task AddCompanyAsync(Company company)
        {
            await dbcontext.Companies.AddAsync(company);
            await dbcontext.SaveChangesAsync();
        }

        public void DeleteCompany(Company company)
        {
            dbcontext.Companies.Remove(company);
            dbcontext.SaveChanges();
        }

        public async Task DeleteCompanyAsync(Company company)
        {
            dbcontext.Companies.Remove(company);
            await dbcontext.SaveChangesAsync();
        }

        public Company GetCompanyByName(string name)
        {
            return dbcontext.Companies.Where(company => company.Name == name).First();
        }

        public async Task<Company> GetCompanyByNameAsync(string name)
        {
            return await dbcontext.Companies.Where(company => company.Name == name).FirstAsync();
        }

        public void UpdateCompany(Company company)
        {
            dbcontext.Companies.Update(company);
            dbcontext.SaveChanges();
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            dbcontext.Companies.Update(company);
            await dbcontext.SaveChangesAsync();
            
        }
    }
}
