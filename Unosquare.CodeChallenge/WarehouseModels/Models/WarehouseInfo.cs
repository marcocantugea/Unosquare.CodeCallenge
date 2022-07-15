using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Interfaces;

namespace WarehouseModels.Models
{
    public class WarehouseInfo : IWarehouseInfo
    {
        private int _id;
        private string _name;
        private string _code;
        private bool _active; 
        private ICollection<Product> _products;

        public int id { get => _id; set => _id=value; }
        public string name { get => _name; set => _name=value; }
        public string code { get => _code; set => _code=value; }
        public bool active { get => _active; set => _active=true; }
        public ICollection<Product> products { get => _products; set => _products=value; }
    }
}
