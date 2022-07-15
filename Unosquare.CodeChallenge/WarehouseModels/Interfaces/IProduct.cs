using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Models;

namespace WarehouseModels.Interfaces
{
    public interface IProduct : IModel
    {
        public int id { set; get; }
        public string name { set; get; }
        public string description { set; get; }
        public int ageRestriction { set; get; }
        public int companyId { set; get; }
        public Company company { set; get; }
        public decimal price { set; get; }
        public string imageIurl { set; get; }

        public int storeid { set; get; }
        public Store store { set; get; }

        public ICollection<WarehouseInfo> warehouseInfo { set; get; }
    }
}
