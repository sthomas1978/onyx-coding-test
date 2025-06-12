using Microsoft.EntityFrameworkCore;
using Onyx.Products.Web.Api.Domain;

namespace Onyx.Products.Web.Api.Data
{
    public class EFProductsRepository(ProductsContext ctx) : IProductsRepository
    {
        public Task<List<Product>> GetAll() => ctx.Products.ToListAsync();
        public Task<List<Product>> GetProductsByColor(Color color) => ctx.Products.Where(p => p.Color == color).ToListAsync();
    }
}