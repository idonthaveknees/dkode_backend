using FactoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FactoryAPI
{
    public class FactoryDbContext : DbContext
    {
        public FactoryDbContext()
        {
        }

        public FactoryDbContext(DbContextOptions<FactoryDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item>? Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("FactoryContext");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
