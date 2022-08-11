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
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public int AgeRestriction { set; get; }
        public int CompanyId { set; get; }
        public Company Company { set; get; }
        public decimal Price { set; get; }
        public string ImageIurl { set; get; }

        public int Storeid { set; get; }
        public Store Store { set; get; }

        public ICollection<WarehouseInfo> WarehouseInfo { set; get; }
    }
}
