using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseModels.Interfaces;

namespace WarehouseModels.Models
{
    public class ProductWarehouse : IModel
    {
        [ForeignKey("Products")]
        public int productId { get; set; }

        [ForeignKey("Warehouses")]
        public int warehouseId { get; set; }
        public int stock { get; set; }  

    }
}
