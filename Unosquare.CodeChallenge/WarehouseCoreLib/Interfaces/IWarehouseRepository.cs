using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseCoreLib.DataAccess;
using WarehouseModels.Interfaces;

namespace WarehouseCoreLib.Interfaces
{
    public interface IWarehouseRepository<IModel>
    {
        public WarehouseDbContext dbcontext { get; set; }

        public void add(IModel model);
        public void addAsync(IModel model);
        public void update(IModel model);
        public void updateAsync(IModel model);
        public void delete(IModel model);
        public void deleteAsync(IModel model);
        public void save();
        public void saveAsync(IModel model);

        public IModel getById(int id);
        public Task<IModel> getByIdAsync(int id);
        public IEnumerable<IModel> findAll(int limit=0);
        public Task<IEnumerable<IModel>> findAllAsync();

    }
}
