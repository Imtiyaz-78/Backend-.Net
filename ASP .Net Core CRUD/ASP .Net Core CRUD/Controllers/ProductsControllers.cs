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

    }
}
