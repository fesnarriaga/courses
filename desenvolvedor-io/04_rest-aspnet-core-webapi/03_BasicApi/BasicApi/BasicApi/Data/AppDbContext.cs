using BasicApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
