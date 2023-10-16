using FactoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FactoryAPI
{
    public class FactoryDbContext : DbContext
    {
        public DbSet<Item>? Items { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("server=.;database=(localdb)\\ProjectModels;trusted_connection=true;TrustServerCertificate=True; ");
    }
}
