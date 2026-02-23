using AutoMapper;
using DataAccessLayer.Entities;
using DataLogicLayer.DTO;

namespace DataLogicLayer.Mappers;
public class ProductAddRequestToProductProfile:Profile
{
    public ProductAddRequestToProductProfile()
    {
        CreateMap<ProductAddRequest, Product>()
            .ForMember(idx => idx.ProductName, dest => dest.MapFrom(i => i.ProductName))
            .ForMember(idx => idx.Category, dest => dest.MapFrom(i => i.CategoryOptions))
            .ForMember(idx => idx.UnitPrice, dest => dest.MapFrom(i => i.UnitPrice))
            .ForMember(idx => idx.QuantityInStock, dest => dest.MapFrom(i => i.Quantity))
            .ForMember(idx => idx.ProductId, dest => dest.Ignore());
    }

}
