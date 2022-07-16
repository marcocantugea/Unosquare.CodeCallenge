using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseCoreLib.Base;
using WarehouseCoreLib.Interfaces;
using WarehouseModels.Models;

namespace WarehouseRepositories.Repositories
{
    public class CompanyRepository : Repository<Company>
    {
       
        public Company getCompanyByName(string name)
        {
            return dbcontext.Companies.Where(company => company.Name == name).First();
        }

    }
}
