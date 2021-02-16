using Microsoft.EntityFrameworkCore;
using ModelApp.MVC.Models;

namespace ModelApp.MVC.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
