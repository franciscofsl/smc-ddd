using NSubstitute;
using Semicrol.DddTemplate.Application.Products.Commands.RateProduct;
using Semicrol.DddTemplate.Core.Products;
using Semicrol.DddTemplate.Core.Products.ValueObjects;
using Shouldly;

namespace Semicrol.DddTemplate.Application.Tests.Products.Commands;

public class RateProductCommandHandlerTest
{
    [Fact]
    public async Task Handle_RateProductCommand_Should_Return_Rating()
    {
        var product = ProductBuilder.Build();
        var repository = Substitute.For<IProductRepository>();
        var handler = new RateProductCommandHandler(repository);
        var command = new RateProductCommand
        {
            ProductId = product.Id,
            User = "TestUser",
            Value = 4
        };

        repository.GetByIdAsync(Arg.Any<ProductId>()).Returns(product);

        var result = await handler.Handle(command);

        result.ShouldNotBeNull();
        result.User.ShouldBe(command.User);
        result.Value.ShouldBe(command.Value);
    }

    [Fact]
    public async Task Handle_RateProductCommand_Should_Rate_Product()
    {
        var product = ProductBuilder.Build();
        var repository = Substitute.For<IProductRepository>();
        var handler = new RateProductCommandHandler(repository);
        var command = new RateProductCommand
        {
            ProductId = product.Id,
            User = "TestUser",
            Value = 4
        };

        repository.GetByIdAsync(Arg.Any<ProductId>()).Returns(product);

        await handler.Handle(command);

        product.Ratings.Values.ShouldNotBeEmpty();
    }
}