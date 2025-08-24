using ASP_.Net_Core_CRUD.Data;
using ASP_.Net_Core_CRUD.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP_.Net_Core_CRUD.Reposetry
{
    public class ProductReposetory
    {
        private readonly AppDbContext db;
          public ProductReposetory(AppDbContext dbContext) { 
            this.db = dbContext; 
          }

        public async Task<List<Product>> getAllProduct()
        {
            return await db.Products.ToListAsync();
        }

        public async Task SaveProduct(Product vm)
        {
            
            await db.Products.AddAsync(vm);
            await db.SaveChangesAsync();
        }

    }
}
