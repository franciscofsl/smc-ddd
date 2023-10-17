using Microsoft.AspNetCore.Mvc;
using Semicrol.DddTemplate.Api.Dtos.Products;
using Semicrol.DddTemplate.Api.Shared;
using Semicrol.DddTemplate.Application.Products.Commands.CreateProduct;
using Semicrol.DddTemplate.Application.Shared.Cqrs.Commands;
using Swashbuckle.AspNetCore.Annotations;

namespace Semicrol.DddTemplate.Api.Endpoints.Products;

public class Create : BaseAsyncEndpoint
    .WithRequest<CreateProductDto>
    .WithResponse<ProductDto>
{
    private readonly ICommandDispatcher _commandDispatcher;

    public Create(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [SwaggerOperation(
        Summary = "Create product",
        Description = "Create a product",
        OperationId = "Products_Create",
        Tags = new[] { "Products" })]
    [HttpPost(ApiRoutes.Products)]
    public override async Task<ActionResult<ProductDto>> HandleAsync([FromForm] CreateProductDto request,
        CancellationToken cancellationToken = default)
    {
        var product = await _commandDispatcher.Dispatch(new CreateProductCommand
        {
            Description = request.Description,
            Title = request.Title
        });

        return Ok(new ProductDto
        {
            Id = product.Id,
            Description = product.Information.Description,
            Title = product.Information.Title
        });
    }
}