using Onyx.Products.Web.Api.Domain;
namespace Onyx.Products.Web.Api.Data;

public interface IProductsRepository
{
    Task<IEnumerable<Product>> GetAll();
    Task<IEnumerable<Product>> GetProductsByColor(Color color);
}
