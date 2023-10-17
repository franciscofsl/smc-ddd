using Microsoft.AspNetCore.Mvc;
using Semicrol.DddTemplate.Api.Dtos.Products;
using Semicrol.DddTemplate.Api.Shared;
using Semicrol.DddTemplate.Application.Products.Commands.RateProduct;
using Semicrol.DddTemplate.Application.Shared.Cqrs.Commands;
using Swashbuckle.AspNetCore.Annotations;

namespace Semicrol.DddTemplate.Api.Endpoints.Products;

public class Rate : BaseAsyncEndpoint.WithRequest<CreateProductRateDto>.WithResponse<RatingDto>
{
    private readonly ICommandDispatcher _commandDispatcher;

    public Rate(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [SwaggerOperation(
        Summary = "Rate product",
        Description = "Rate a product",
        OperationId = "Products_Rate",
        Tags = new[] { "Products" })]
    [HttpPost(ApiRoutes.ProductRates)]
    public override async Task<ActionResult<RatingDto>> HandleAsync([FromForm] CreateProductRateDto request,
        CancellationToken cancellationToken = default)
    {
        var rating = await _commandDispatcher.Dispatch(new RateProductCommand
        {
            ProductId = request.ProductId,
            User = request.User,
            Value = request.Value
        });

        return Ok(new RatingDto
        {
            Value = rating.Value,
            User = rating.User
        });
    }
}