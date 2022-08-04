using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Interfaces;

namespace WarehouseModels.Models
{
    public class Company : ICompany, IModel
    {
        private int _id;
        private string _name;

        public int id { get => _id; set => _id=value; }
        public string name { get => _name; set => _name=value; }
    }
}
