using NSubstitute;
using Semicrol.DddTemplate.Application.Products.Queries.GetProductRatings;
using Semicrol.DddTemplate.Core.Products;
using Semicrol.DddTemplate.Core.Products.ValueObjects;
using Shouldly;

namespace Semicrol.DddTemplate.Application.Tests.Products.Queries;

public class GetProductRatingsQueryHandlerTest
{
    [Fact]
    public async Task Handle_GetProductRatingQuery_Should_Return_Ratings()
    {
        var product = ProductBuilder.Build();
        var repository = Substitute.For<IProductRepository>();
        var handler = new GetProductRatingsQueryHandler(repository);
        var query = new GetProductRatingQuery
        {
            ProductId = product.Id
        };

        repository.GetByIdAsync(Arg.Any<ProductId>()).Returns(product);
        var result = await handler.Handle(query);
        result.Values.ShouldBeEmpty();
    }
}