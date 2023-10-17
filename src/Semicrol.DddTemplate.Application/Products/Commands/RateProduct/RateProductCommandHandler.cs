using Semicrol.DddTemplate.Application.Shared.Cqrs.Commands;
using Semicrol.DddTemplate.Core.Common.ValueObjects;
using Semicrol.DddTemplate.Core.Products;
using Semicrol.DddTemplate.Core.Products.ValueObjects;

namespace Semicrol.DddTemplate.Application.Products.Commands.RateProduct;

public class RateProductCommandHandler : ICommandHandler<RateProductCommand, Rating>
{
    private readonly IProductRepository _repository;

    public RateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Rating> Handle(RateProductCommand command, CancellationToken token = default)
    {
        var productIdToSearch = new ProductId(command.ProductId);
        var product = await _repository.GetByIdAsync(productIdToSearch);

        var rate = product.Rate(command.User, command.Value);

        await _repository.UpdateAsync(product);
        await _repository.SaveChangesAsync();

        return rate;
    }
}