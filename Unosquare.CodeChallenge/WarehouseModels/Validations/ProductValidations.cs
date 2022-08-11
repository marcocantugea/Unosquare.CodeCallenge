using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Interfaces;
using WarehouseModels.Models;

namespace WarehouseModels.Validations
{
    public class ProductValidations : AbstractValidator<Product>,IValidation<Product>
    {
        public ProductValidations()
        {
            RuleFor(product => product.Name).NotEmpty().MaximumLength(50);
            RuleFor(product => product.AgeRestriction).NotEmpty().GreaterThan(0).LessThanOrEqualTo(100);
            RuleFor(product => product.Price).NotEmpty().GreaterThan(0);
            RuleFor(product => product.CompanyId).NotEmpty().GreaterThan(0);
            RuleFor(product=> product.Description).MaximumLength(100);
        }

        public void ValidateModel(Product model)
        {
            Validate(model);
        }
    }
}
