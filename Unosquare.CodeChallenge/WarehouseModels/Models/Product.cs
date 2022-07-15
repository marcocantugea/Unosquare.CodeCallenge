using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Interfaces;

namespace WarehouseModels.Models
{
    public class Product : IProduct
    {
        private int _id;
        private string _name;
        private string _description;
        private int _ageRestriction;
        private int _companyId;
        private Company _company;
        private decimal _price;
        private string _imageUrl;
        private int _storeid;
        private Store _store;
        private ICollection<WarehouseInfo> _warehouses;

        public int id { get => _id; set => _id = value; }
        public string name { get => _name; set => _name = value; }
        public string description { get => _description; set => _description = value; }
        public int ageRestriction { get => _ageRestriction; set => _ageRestriction = value; }
        public Company company { get => _company; set => _company = value; }

        [Column(TypeName = "decimal(9, 2)")]
        public decimal price { get => _price; set => _price = value; }
        public string imageIurl { get => _imageUrl; set => _imageUrl=value; }
        [ForeignKey("Companies")]
        public int companyId { get => _companyId; set => _companyId = value; }
        [ForeignKey("Stores")]
        public int storeid { get => _storeid; set => _storeid=value; }
        public Store store { get => _store; set => _store=value; }
        public ICollection<WarehouseInfo> warehouseInfo { get => _warehouses; set => _warehouses=value; }
    }
}
