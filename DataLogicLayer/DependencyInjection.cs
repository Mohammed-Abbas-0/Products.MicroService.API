using DataLogicLayer.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace DataLogicLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ProductAddRequestToProductProfile).Assembly);
        //services.AddFluentValidationAutoValidation<ProductAddRequestValidator>();
        return services;
    }
}

