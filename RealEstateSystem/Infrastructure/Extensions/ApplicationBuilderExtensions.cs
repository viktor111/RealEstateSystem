using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Data;

namespace RealEstateSystem.Infrastructure.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder PrepareDataBase(this IApplicationBuilder applicationBuilder)
    {
        using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
        var services = serviceScope.ServiceProvider;

        MigrateDatabase(services);

        return applicationBuilder;
    }

    private static void MigrateDatabase(IServiceProvider services)
    {
        var dbContext = services.GetRequiredService<RealEstateDbContext>();
        dbContext.Database.EnsureCreated();
        dbContext.Database.Migrate();
    }
}