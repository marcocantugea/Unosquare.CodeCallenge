using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Models;

namespace WarehouseModels.Interfaces
{
    public interface IStore
    {
        public int Id { set; get; }
        public string storeName { set; get; }
        public string address { set; get; }
        public string city { set; get; }
        public List<Product> products { set; get; }
    }
}
