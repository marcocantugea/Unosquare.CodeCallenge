
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
            builder.Property(prop => prop.Name).IsRequired().HasMaxLength(50);
            builder.HasData(getInitalData());
        }

        protected List<Company> getInitalData()
        {
            List<Company>  companies = new List<Company>();

            companies.Add(new Company() {Id=1, Name="Mattel"});
            companies.Add(new Company() {Id=2, Name = "Marvel" });
            companies.Add(new Company() {Id=3, Name = "Nintento" });
            companies.Add(new Company() {Id=4, Name = "Sony" });
            companies.Add(new Company() {Id=5, Name = "Microsot" });

            return companies;

        }
    }
}
