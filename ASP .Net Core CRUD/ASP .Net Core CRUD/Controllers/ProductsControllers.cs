using ASP_.Net_Core_CRUD.Model;
using ASP_.Net_Core_CRUD.Reposetry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_.Net_Core_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsControllers : ControllerBase
    {
        private readonly ProductReposetory prodt;

        public ProductsControllers(ProductReposetory prodtResposetory)
        {
            this.prodt = prodtResposetory;
        }

        [HttpGet]
        public async Task<ActionResult> ProductList() {
            var allProduct = await prodt.getAllProduct();
            return Ok(allProduct);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product data is null.");
            }

            try
            {
                await prodt.SaveProduct(product);
                return Ok("Product saved successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (product == null)
                return BadRequest("Product data is null.");

            product.Id = id; // Force route ID to match the body

            try
            {
                await prodt.UpdateProduct(product);
                return Ok("Product updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating product: {ex.Message}");
            }
        }


        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await prodt.DeleteProduct(id);
                return Ok("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error deleting product: {ex.Message}");
            }
        }

        // GET: api/ProductsControllers/2
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await prodt.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            return Ok(product);
        }






    }
}
