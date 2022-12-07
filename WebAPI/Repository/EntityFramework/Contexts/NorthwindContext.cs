using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Repository.EntityFramework.Contexts
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Northwind;Username=postgres;Password=123456");
    }
}
