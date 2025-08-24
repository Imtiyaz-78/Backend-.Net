using ASP_.Net_Core_CRUD.Reposetry;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_.Net_Core_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase

    {
        private readonly ProductReposetory prodt;

        public EmployeeController(ProductReposetory prodtResposetory)
        {
            this.prodt = prodtResposetory;
        }

        [HttpGet]
        public async Task<ActionResult> ProductList()
        {
            var allProduct = await prodt.getAllProduct();
            return Ok(allProduct);
        }
    }
}
