using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;

namespace RealEstateSystem.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        const string connectionString =
            "Server=127.0.0.1;Database=real_estate_db;Port=5432;UserId=viktordraganov;Password=viktor11;";
        
        services.AddDbContext<RealEstateDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("DefaultConnectionString") ?? connectionString);
        });

        return services;
    }
}