using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Models;

namespace WarehouseModels.Interfaces
{
    public interface IWarehouseInfo : IModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public bool active { get; set; }

        public ICollection<Product> products { get; set; }

    }
}
