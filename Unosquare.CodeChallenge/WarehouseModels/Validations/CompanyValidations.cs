using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Interfaces;
using WarehouseModels.Models;

namespace WarehouseModels.Validations
{
    public class CompanyValidations : AbstractValidator<Company>, IValidation<Company>
    {

        public CompanyValidations() {
            RuleFor(company=> company.name).NotEmpty();
        }

        public void setRuleForId()
        {
            RuleFor(company => company.id).NotEmpty().GreaterThan(0);

        }

        public void ValidateModel(Company model)
        {
            Validate(model);
        }
    }
}
