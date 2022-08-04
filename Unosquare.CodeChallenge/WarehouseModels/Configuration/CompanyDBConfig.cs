
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Interfaces;
using WarehouseModels.Models;

namespace WarehouseModels.Configuration
{
    public class CompanyDBConfig : IEntityTypeConfiguration<Models.Company>,IConfigurationDB
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(prop => prop.name).IsRequired().HasMaxLength(50);
            builder.HasData(GetInitalData());
        }

        protected List<Company> GetInitalData()
        {
            List<Company>  companies = new List<Company>();

            companies.Add(new Company() {id=1, name="Mattel"});
            companies.Add(new Company() {id=2, name = "Marvel" });
            companies.Add(new Company() {id=3, name = "Nintento" });
            companies.Add(new Company() {id=4, name = "Sony" });
            companies.Add(new Company() {id=5, name = "Microsot" });

            return companies;

        }
    }
}
