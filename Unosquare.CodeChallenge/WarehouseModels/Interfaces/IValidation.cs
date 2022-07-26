using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseModels.Interfaces
{
    public interface IValidation<IModel>
    {
        public void ValidateModel(IModel model);
    }
}
