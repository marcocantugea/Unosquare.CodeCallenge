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

        public void ValidateEmptyNewModel(Company model)
        {
            if(String.IsNullOrEmpty(model.Name)) throw new Exception("company name value empty");
        }

        public void ValidateCompleteModel(Company model)
        {
            if(model.Id==null) throw new Exception("company id value empty");
            if (model.Id <=0 ) throw new Exception("company id value empty");
            ValidateEmptyNewModel(model);
        }
    }
}
