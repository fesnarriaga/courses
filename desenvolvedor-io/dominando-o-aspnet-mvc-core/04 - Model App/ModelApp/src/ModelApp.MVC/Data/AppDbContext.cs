using Microsoft.EntityFrameworkCore;

namespace ModelApp.MVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
