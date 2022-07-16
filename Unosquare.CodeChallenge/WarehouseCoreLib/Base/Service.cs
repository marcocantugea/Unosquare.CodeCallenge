using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseCoreLib.Interfaces;
using WarehouseModels.Interfaces;

namespace WarehouseCoreLib.Base
{
    public abstract class Service<IModel> : IService<IModel>
    {
        private IWarehouseRepository<IModel> _repository;

        public IWarehouseRepository<IModel> repository { get =>_repository; set => _repository=value; }
    }
}
