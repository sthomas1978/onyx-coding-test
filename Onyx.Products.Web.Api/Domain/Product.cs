namespace Onyx.Products.Web.Api.Domain;

public record Product(int Id, string Name, decimal Price, Color Color);

public enum Color
{
    Red,
    Green,
    Blue,
    Black,
    White,
    Yellow
}
