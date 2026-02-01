using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        string host = Environment.GetEnvironmentVariable("MYSQL_HOST") ?? "";
        string password = Environment.GetEnvironmentVariable("MYSQL_PASSWORD") ?? "";

        string connectionString = configuration.GetConnectionString("DefaultConnection")!
            .Replace("$MYSQL_HOST", host)
            .Replace("$MYSQL_PASSWORD", password);

        services.AddDbContext<AppDbContext>(options =>
                 options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString)));




        return services;
    }
}

