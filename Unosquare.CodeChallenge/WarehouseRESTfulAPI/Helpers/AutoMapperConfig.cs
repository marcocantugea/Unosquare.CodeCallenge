using AutoMapper;
using WarehouseModels.Models;
using WarehouseRESTfulAPI.RequestModels;

namespace WarehouseRESTfulAPI.Helpers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProductRequestModel, Product>();
        }
    }
}
