using DataAccessLayer.Repositories;
using DataAccessLayer.RepositoriesContracts;
using DataLogicLayer.Mappers;
using DataLogicLayer.ServiceContracts;
using DataLogicLayer.Services;
using DataLogicLayer.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DataLogicLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ProductAddRequestToProductProfile).Assembly);
        // FluentValidation
        services.AddValidatorsFromAssemblyContaining<ProductAddRequestValidator>();
        services.AddScoped<IProductsRepository,ProductsRepository>();
        services.AddScoped<IProductService,ProductService>();
        return services;
    }
}

