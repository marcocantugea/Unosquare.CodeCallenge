using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseCoreLib.DataAccess;
using WarehouseCoreLib.Interfaces;
using WarehouseModels.Interfaces;

namespace WarehouseCoreLib.Base
{
    public abstract class Repository<IModel> : IWarehouseRepository<IModel> where IModel : class
    {
        private WarehouseDbContext _db;

        public WarehouseDbContext dbcontext { get => _db; set => _db=value; }

        public void add(IModel model)
        {
            dbcontext.Add(model);
        }

        public async void addAsync(IModel model)
        {
           await dbcontext.AddAsync(model);
        }

        public void delete(IModel model)
        {
            dbcontext.Remove(model);
        }

        public async void deleteAsync(IModel model)
        {
            await Task.Run(() => dbcontext.Remove(model));
        }

        public IEnumerable<IModel> findAll(int limit = 0)
        {
            if(limit==0) return dbcontext.Set<IModel>();
            return dbcontext.Set<IModel>().Take(limit);
        }

        public async Task<IEnumerable<IModel>> findAllAsync()
        {
            return await Task.Run(() => dbcontext.Set<IModel>()); 
        }

        public IModel getById(int id)
        {
            return dbcontext.Find<IModel>(id);
        }

        public async Task<IModel> getByIdAsync(int id)
        {
            return await dbcontext.FindAsync<IModel>(id);
        }

        public void save()
        {
            dbcontext.SaveChanges();
        }

        public async void saveAsync(IModel model)
        {
            await dbcontext.SaveChangesAsync();
        }

        public void update(IModel model)
        {
            dbcontext.Update(model);
        }

        public async void updateAsync(IModel model)
        {
            await Task.Run(() => dbcontext.Update(model));
        }

    }
}
