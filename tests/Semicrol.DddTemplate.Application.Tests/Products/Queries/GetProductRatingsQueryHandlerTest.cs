using Moq;
using NSubstitute;
using Semicrol.DddTemplate.Application.Products.Queries.GetProductRatings;
using Semicrol.DddTemplate.Core.Products;
using Semicrol.DddTemplate.Core.Products.ValueObjects;
using Shouldly;

namespace Semicrol.DddTemplate.Application.Tests.Products.Queries;

public class GetProductRatingsQueryHandlerTest
{
    [Fact]
    public async Task Handle_GetProductRatingQuery_Should_Return_Ratings_Using_NSubstitute()
    {
        var product = ProductBuilder.Build();

        var repository = Substitute.For<IProductRepository>();
        repository.GetByIdAsync(Arg.Any<ProductId>()).Returns(product);

        var handler = new GetProductRatingsQueryHandler(repository);

        var query = new GetProductRatingQuery
        {
            ProductId = product.Id
        };

        var result = await handler.Handle(query);

        result.Values.ShouldBeEmpty();
    }

    [Fact]
    public async Task Handle_GetProductRatingQuery_Should_Return_Ratings_Using_Moq()
    {
        var product = ProductBuilder.Build();

        var repositoryMock = new Mock<IProductRepository>();
        repositoryMock.Setup(_ => _.GetByIdAsync(It.IsAny<ProductId>())).ReturnsAsync(product);

        var handler = new GetProductRatingsQueryHandler(repositoryMock.Object);

        var query = new GetProductRatingQuery
        {
            ProductId = product.Id
        };

        var result = await handler.Handle(query);

        result.Values.ShouldBeEmpty();
    }

    [Fact]
    public async Task Handle_GetProductRatingQuery_Should_Return_Ratings_With_Stub()
    {
        var repository = new ProductRepositoryStub();

        var handler = new GetProductRatingsQueryHandler(repository);

        var query = new GetProductRatingQuery
        {
            ProductId = Guid.NewGuid()
        };

        var result = await handler.Handle(query);

        result.Values.ShouldHaveSingleItem();
    }
}