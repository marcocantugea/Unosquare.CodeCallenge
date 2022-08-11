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
            newProduct.Name = model.name;
            newProduct.Description = model.description;
            newProduct.AgeRestriction = model.ageRestriction;
            newProduct.CompanyId = model.companyId;
            newProduct.Price = model.price;
            newProduct.ImageIurl = model.imageIurl;
            newProduct.Storeid = model.storeId;

            return newProduct;
        }

    }
}
