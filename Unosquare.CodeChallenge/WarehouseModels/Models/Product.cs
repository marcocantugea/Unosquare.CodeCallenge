using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

        [JsonPropertyName("id")]
        public int Id { get => _id; set => _id = value; }

        [JsonPropertyName("name")]
        public string Name { get => _name; set => _name = value; }

        [JsonPropertyName("description")]
        public string Description { get => _description; set => _description = value; }
        
        [JsonPropertyName("ageRestriction")]
        public int AgeRestriction { get => _ageRestriction; set => _ageRestriction = value; }

        [JsonPropertyName("company")]
        public Company Company { get => _company; set => _company = value; }

        [JsonPropertyName("price")]
        [Column(TypeName = "decimal(9, 2)")]
        public decimal Price { get => _price; set => _price = value; }

        [JsonPropertyName("imageIurl")]
        public string ImageIurl { get => _imageUrl; set => _imageUrl=value; }

        [JsonPropertyName("companyId")]
        [ForeignKey("Companies")]
        public int CompanyId { get => _companyId; set => _companyId = value; }
        [ForeignKey("Stores")]
        public int Storeid { get => _storeid; set => _storeid=value; }
        
        [JsonIgnore] 
        public Store Store { get => _store; set => _store=value; }
        [JsonIgnore]
        public ICollection<WarehouseInfo> WarehouseInfo { get => _warehouses; set => _warehouses=value; }
    }
}
