using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Interfaces;
using WarehouseModels.Models;

namespace WarehouseModels.Validations
{
    public class ProductValidatons : IValidation<Product>
    {
        public void Validate(Product model)
        {
           ValidateCompleteModel(model);
        }

        public void ValidateNewProductModel(Product model)
        {
            ValidateName(model);
            ValidatePrice(model);
            ValidateCompanyId(model);
            ValidateAgeRestriction(model);

        }

        public void ValidateCompleteModel(Product model)
        {
            ValidateName(model);
            ValidatePrice(model);
            ValidateCompanyId(model);
            ValidateAgeRestriction(model);
            ValidateDescription(model);
        }

        public void ValidateAgeRestriction(Product model)
        {
            if (model.ageRestriction < 0) throw new Exception("Age restriction cannot be less than 0");
            if (model.ageRestriction == 0) throw new Exception("Age restriction cannot be 0");
            if (model.ageRestriction > 100) throw new Exception("Age restriction cannot be grather than 0");
        }

        public void ValidatePrice(Product model)
        {
            if (model.price == null) throw new Exception("invalid price, empty int");
            if (model.price < 0) throw new Exception("invalid price, price cannot be less than 0");
            if (model.price == 0) throw new Exception("price cannot be 0");
        }

        public void ValidateName(Product model)
        {
            if (String.IsNullOrEmpty(model.name)) throw new Exception("invalid name, empty string");
        }

        public void ValidateCompanyId(Product model)
        {
            if (model.companyId == 0) throw new Exception("Company id cannot be 0");
            if (model.companyId < 0) throw new Exception("Invalid company id, cannot be less than 0");
        }

        public void ValidateDescription(Product model)
        {
            if (String.IsNullOrEmpty(model.description)) throw new Exception("Description fill can not be empty");
        }


    }
}
