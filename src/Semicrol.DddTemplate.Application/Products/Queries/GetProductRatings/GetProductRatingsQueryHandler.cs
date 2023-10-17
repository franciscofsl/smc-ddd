using Semicrol.DddTemplate.Application.Shared.Cqrs.Queries;
using Semicrol.DddTemplate.Core.Common.ValueObjects;
using Semicrol.DddTemplate.Core.Products;
using Semicrol.DddTemplate.Core.Products.ValueObjects;

namespace Semicrol.DddTemplate.Application.Products.Queries.GetProductRatings;

public class GetProductRatingsQueryHandler : IQueryHandler<GetProductRatingQuery, Ratings>
{
    private readonly IProductRepository _productRepository;

    public GetProductRatingsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Ratings> Handle(GetProductRatingQuery command, CancellationToken cancellationToken = default)
    {
        var product = await _productRepository.GetByIdAsync(new ProductId(command.ProductId));

        return product.Ratings;
    }
}