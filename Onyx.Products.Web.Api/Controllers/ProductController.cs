using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onyx.Products.Web.Api.Data;
using Onyx.Products.Web.Api.Domain;
using Onyx.Products.Web.Api.Dto;

namespace Onyx.Products.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProductController(
        IProductsRepository repo,
        ILogger<ProductController> logger) : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = (await repo.GetAll())
                .Select(ProductDto.From);

            return new OkObjectResult(products);
        }

        [HttpGet("ByColor")]
        public async Task<IActionResult> GetProductsByColor(Color color)
        {
            var products = (await repo.GetProductsByColor(color))
                .Select(ProductDto.From);

            return new OkObjectResult(products);
        }
    }
}
