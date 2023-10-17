using Semicrol.DddTemplate.Core.Products.Events;
using Semicrol.DddTemplate.Core.Shared.Events;

namespace Semicrol.DddTemplate.Application.Products.Events;

public class ProductRatedEventHandler : IDomainEventHandler<ProductRated>
{
    public Task Handle(ProductRated domainEvent, CancellationToken token = default)
    {
        // log action
        return Task.CompletedTask;
    }
}