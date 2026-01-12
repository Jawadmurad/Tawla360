using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tawla._360.Domain.Entities.MenuEntities;
using Tawla._360.Domain.Entities.RestaurantEntities;
using Tawla._360.Domain.Entities.Settings;
using Tawla._360.Domain.Entities.UsersEntities;

namespace Tawla._360.Persistence.DbContexts;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Surcharge> Surcharges { get; set; }
    public DbSet<Tax> Taxes { get; set; }
    public DbSet<Modifier> Modifiers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemPrice> ItemPrices { get; set; }
    public DbSet<ModifierGroup> ModifierGroups { get; set; }
    public DbSet<ModifierOption> ModifierOptions { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
}
