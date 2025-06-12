using Onyx.Products.Web.Api.Domain;
namespace Onyx.Products.Web.Api.Data;

public interface IProductsRepository
{
    Task<List<Product>> GetAll();
    Task<List<Product>> GetProductsByColor(Color color);
}
