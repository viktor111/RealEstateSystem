using Microsoft.EntityFrameworkCore;
using RealEstateSystem.Models;

namespace RealEstateSystem.Data;

public class RealEstateDbContext : DbContext
{
    public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options)
        :base(options)
    {
    }
    
    public DbSet<PropertyEstate> PropertyEstates { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<PropertyEstate>().HasKey(e => e.Id);
        
        base.OnModelCreating(builder);
    }
}