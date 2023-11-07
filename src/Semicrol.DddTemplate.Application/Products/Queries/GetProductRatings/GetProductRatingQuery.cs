using Semicrol.DddTemplate.Application.Shared.Cqrs.Queries;
using Semicrol.DddTemplate.Core.Common.ValueObjects;
using Semicrol.DddTemplate.Core.Products;

namespace Semicrol.DddTemplate.Application.Products.Queries.GetProductRatings;

public class GetProductRatingQuery : IQuery<Ratings>
{
    public Guid ProductId { get; set; }
}