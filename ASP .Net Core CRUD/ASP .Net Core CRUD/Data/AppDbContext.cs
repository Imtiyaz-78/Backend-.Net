using ASP_.Net_Core_CRUD.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP_.Net_Core_CRUD.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        public DbSet<Product> Products { get; set; }
    }
}
