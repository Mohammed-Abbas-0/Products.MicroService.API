using AutoMapper;
using DataAccessLayer.Entities;
using DataLogicLayer.DTO;

namespace DataLogicLayer.Mappers;
public class ProductReponseToProductProfile : Profile
{
    public ProductReponseToProductProfile()
    {
        CreateMap<Product,ProductResponse>()
            .ForMember(idx => idx.ProductName, dest => dest.MapFrom(i => i.ProductName))
            .ForMember(idx => idx.Category, dest => dest.MapFrom(i => i.Category))
            .ForMember(idx => idx.UnitPrice, dest => dest.MapFrom(i => i.UnitPrice))
            .ForMember(idx => idx.Quantity, dest => dest.MapFrom(i => i.QuantityInStock))
            .ForMember(idx => idx.ProductId, dest => dest.MapFrom(i=>i.ProductId));
    }

}
