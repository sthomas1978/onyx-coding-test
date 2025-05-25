using Onyx.Products.Web.Api.Domain;

namespace Onyx.Products.Web.Api.Dto;

public record ProductDto(int Id, string Name, decimal Price, Color Color)
{
    public static ProductDto From(Product product) => new(product.Id, product.Name, product.Price, product.Color);
    public Product To() => new(Id, Name, Price, Color);
}
