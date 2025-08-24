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

        // This for get Product
        public async Task<List<Product>> getAllProduct()
        {
            return await db.Products.ToListAsync();
        }

       // This for Save Product
        public async Task SaveProduct(Product vm)
        {
            
            await db.Products.AddAsync(vm);
            await db.SaveChangesAsync();
        }

        // Update an existing product
        public async Task UpdateProduct(Product vm)
        {
            var existingProduct = await db.Products.FindAsync(vm.Id);
            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }

            existingProduct.ProductName = vm.ProductName;
            existingProduct.ProductPrice = vm.ProductPrice;
            existingProduct.Price = vm.Price;
            existingProduct.ProductDescription = vm.ProductDescription;
            existingProduct.Rating = vm.Rating;
            existingProduct.Satus = vm.Satus;

            await db.SaveChangesAsync();
        }


        public async Task<Product?> GetProductById(int id)
        {
            return await db.Products.FindAsync(id);
        }

        public async Task DeleteProduct(int id)
        {
            var product = await db.Products.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();
        }

    }
}
