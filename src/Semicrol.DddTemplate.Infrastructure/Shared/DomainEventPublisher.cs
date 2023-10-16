using Semicrol.DddTemplate.Application.Contracts;
using Semicrol.DddTemplate.Core.Shared.Events;

namespace Semicrol.DddTemplate.Infrastructure.Shared;

public class DomainEventPublisher : IDomainEventPublisher
{
    private readonly IServiceProvider _serviceProvider;

    public DomainEventPublisher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Publish(IDomainEvent domainEvent)
    {
        var type = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
        dynamic handler = _serviceProvider.GetService(type);
        CancellationToken token = default;
        await handler.Handle((dynamic)domainEvent, token);
    }
}