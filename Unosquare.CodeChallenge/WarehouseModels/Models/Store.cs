using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Interfaces;

namespace WarehouseModels.Models
{
    public class Store : IStore
    {
        private int _id;
        private string _storename;
        private string _address;
        private string _city;
        private List<Product> _products;

        public int Id { get => _id; set => _id=value; }
        public string storeName { get => _storename; set => _storename=value; }
        public string address { get => _address; set =>_address=value; }
        public string city { get => _city; set => _city=value; }
        public List<Product> products { get => _products; set => _products=value; }
    }
}
