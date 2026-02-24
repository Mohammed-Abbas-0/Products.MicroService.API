using AutoMapper;
using DataAccessLayer.Entities;
using DataLogicLayer.DTO;

namespace DataLogicLayer.Mappers;
public class ProductResponseToProductProfile : Profile
{
    private static CategoryOptions ParseCategory(string? category)
    {
        if (string.IsNullOrWhiteSpace(category))
            return CategoryOptions.Electronics;

        return Enum.TryParse<CategoryOptions>(category, true, out var val) ? val : CategoryOptions.Electronics;
    }
    public ProductResponseToProductProfile()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice ?? 0))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.QuantityInStock ?? 0))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
            //.ForMember(dest => dest.Category, opt => opt.MapFrom(src => ParseCategory(src.Category)));

        CreateMap<ProductResponse, Product>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
            .ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.ToString()));
    }
}
