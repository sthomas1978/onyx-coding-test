using Microsoft.EntityFrameworkCore;
using Onyx.Products.Web.Api.Domain;

namespace Onyx.Products.Web.Api.Data;

public class ProductsContext: DbContext
{
    public virtual DbSet<Product> Products { get; set; }
    public ProductsContext() { }
    public ProductsContext(DbContextOptions<ProductsContext> options) : base(options) { }
}
