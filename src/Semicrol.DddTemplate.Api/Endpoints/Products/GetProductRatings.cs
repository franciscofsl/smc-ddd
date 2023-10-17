using Microsoft.AspNetCore.Mvc;
using Semicrol.DddTemplate.Api.Dtos.Products;
using Semicrol.DddTemplate.Api.Shared;
using Semicrol.DddTemplate.Application.Products.Queries.GetProductRatings;
using Semicrol.DddTemplate.Application.Shared.Cqrs.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace Semicrol.DddTemplate.Api.Endpoints.Products;

public class GetProductRatings : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<ProductRatingsDto>
{
    private readonly IQueryDispatcher _queryDispatcher;

    public GetProductRatings(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }
    
    [SwaggerOperation(
        Summary = "Get ratings of product",
        Description = "Get ratings of product",
        OperationId = "Products_GetRatings",
        Tags = new[] { "Products" })]
    [HttpGet(ApiRoutes.ProductRates)]
    public override async Task<ActionResult<ProductRatingsDto>> HandleAsync([FromQuery]Guid request,
        CancellationToken cancellationToken = default)
    {
        var ratings = await _queryDispatcher.Dispatch(new GetProductRatingQuery
        {
            ProductId = request
        });

        var ratingsDto = new ProductRatingsDto
        {
            Ratings = ratings.Values
                .Select(_ => new RatingDto
                {
                    Value = _.Value,
                    User = _.User
                })
                .ToList()
        };

        return Ok(ratingsDto);
    }
}