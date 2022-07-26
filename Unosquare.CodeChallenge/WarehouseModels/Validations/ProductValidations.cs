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
            RuleFor(product => product.name).NotEmpty().MaximumLength(50);
            RuleFor(product => product.ageRestriction).NotEmpty().GreaterThan(0).LessThanOrEqualTo(100);
            RuleFor(product => product.price).NotEmpty().GreaterThan(0);
            RuleFor(product => product.companyId).NotEmpty().GreaterThan(0);
            RuleFor(product=> product.description).MaximumLength(100);
        }

        public void ValidateModel(Product model)
        {
            Validate(model);
        }
    }
}
