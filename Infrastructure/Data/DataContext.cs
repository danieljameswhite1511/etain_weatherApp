using System.Linq;
using System.Reflection;
using Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Weather> Weather { get; set; }
        public DbSet<WeatherSummary> WeatherSummaries { get; set; }
        public DbSet<LocationSearchResult> LocationSearchResults { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }
        public DbSet<UserSearch> UserSearches { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if(Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite"){

                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }
                }

            }

        }

    }
}