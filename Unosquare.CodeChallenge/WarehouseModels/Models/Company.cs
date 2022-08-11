using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WarehouseModels.Interfaces;

namespace WarehouseModels.Models
{
    public class Company : ICompany, IModel
    {
        private int _id;
        private string _name;

        [JsonPropertyName("id")]
        public int Id { get => _id; set => _id=value; }

        [JsonPropertyName("name")]
        public string Name { get => _name; set => _name=value; }
    }
}
