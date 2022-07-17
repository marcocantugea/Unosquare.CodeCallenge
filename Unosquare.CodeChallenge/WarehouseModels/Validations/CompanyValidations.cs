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
    public class CompanyValidations : IValidation<Company>
    {
        public void Validate(Company model)
        {
            ValidateCompleteModel(model);
        }

        public CompanyValidations ValidateEmptyNewModel(Company model)
        {
            if(String.IsNullOrEmpty(model.Name)) throw new Exception("company name value empty");
            return this;
        }

        public CompanyValidations ValidateCompleteModel(Company model)
        {
            if(model.Id==null) throw new Exception("company id value empty");
            if (model.Id <=0 ) throw new Exception("company id value empty");
            ValidateEmptyNewModel(model);
            return this;
        }
    }
}
