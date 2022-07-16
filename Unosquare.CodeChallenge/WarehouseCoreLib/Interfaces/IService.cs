using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Models;

namespace WarehouseCoreLib.Interfaces
{
    public interface IService<IModel>
    {
        IWarehouseRepository<IModel> repository { set; get; }
    }
}
