using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Onyx.Products.Web.Api.Controllers;
using Onyx.Products.Web.Api.Data;
using Onyx.Products.Web.Api.Domain;
using Onyx.Products.Web.Api.Dto;

namespace Onyx.Products.Web.Api.Tests.Unit;

public class ProductControllerTests
{
    private readonly ProductController _sut;
    private readonly IProductsRepository _repo = Substitute.For<IProductsRepository>();
    private readonly ILogger<ProductController> _logger = Substitute.For<ILogger<ProductController>>();

    public ProductControllerTests()
    {
        _sut = new(_repo, _logger);
    }

    [Fact]
    public async Task GetProducts_WhenCalled_ReturnsAllProducts()
    {
        // Arrange
        var data = new List<Product> {
                new(Id: 1, Color: Color.Red, Name: "Product 1", Price: 10 ),
                new(Id: 2, Color: Color.Blue, Name:  "Product 2", Price: 20),
                new(Id: 3, Color: Color.Black, Name: "Product 3", Price: 40 ),
            };

        _repo.GetAll().Returns(
            data);

        // Act
        var result = await _sut.GetProducts() as OkObjectResult;

        // Assert
        Assert.IsType<OkObjectResult>(result);

        var actualProducts = (IEnumerable<ProductDto>)result!.Value!;
        Assert.Equal(3, actualProducts.Count());
    }

    [Fact]
    public async Task GetProductsByColor_SpecifyBlue_ReturnsAllProducts()
    {
        // Arrange
        var data = new List<Product> {
                new(Id: 1, Color: Color.Blue, Name: "Product 1", Price: 10 ),
                new(Id: 2, Color: Color.Blue, Name:  "Product 2", Price: 20),
                new(Id: 3, Color: Color.Blue, Name: "Product 3", Price: 40 ),
            };

        _repo.GetProductsByColor(Arg.Is(Color.Blue)).Returns(
            data);

        // Act
        var result = await _sut.GetProductsByColor(Color.Blue) as OkObjectResult;

        // Assert
        Assert.IsType<OkObjectResult>(result);

        var actualProducts = (IEnumerable<ProductDto>)result!.Value!;
        Assert.Equal(3, actualProducts.Count());
    }
}