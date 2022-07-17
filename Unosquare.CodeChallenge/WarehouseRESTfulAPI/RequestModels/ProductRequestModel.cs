using WarehouseModels.Models;

namespace WarehouseRESTfulAPI.RequestModels
{
    public class ProductRequestModel
    {
        public string name {  get; set; }
        public string description { get; set; }
        public int ageRestriction { get; set; }
        public int companyId { get; set; }
        public decimal price { get; set; }
        public string imageIurl { get; set; }

        public int storeId { get; set; }
        public static Product getModel(ProductRequestModel model)
        {
            Product newProduct = new Product();
            newProduct.name = model.name;
            newProduct.description = model.description;
            newProduct.ageRestriction = model.ageRestriction;
            newProduct.companyId = model.companyId;
            newProduct.price = model.price;
            newProduct.imageIurl = model.imageIurl;
            newProduct.storeid = model.storeId;

            return newProduct;
        }

    }
}
