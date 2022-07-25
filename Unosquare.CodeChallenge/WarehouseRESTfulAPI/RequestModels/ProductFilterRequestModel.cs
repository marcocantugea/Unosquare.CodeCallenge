namespace WarehouseRESTfulAPI.RequestModels
{
    public class ProductFilterRequestModel
    {
        public string field { get; set; }
        public string value { get; set; }
        public int typeField { get; set; } = 0;
        public string whereOperator { get; set; } = "==";

    }

    public enum typeFields
    {
        STRING=0,
        NUMERIC=1,
        BOOLEAN=2,
        DECIMAL=3
    }
}
