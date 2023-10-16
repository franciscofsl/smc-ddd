using Semicrol.DddTemplate.Core.Shared.Events;

namespace Semicrol.DddTemplate.Application.Contracts;

public interface IDomainEventPublisher
{
    Task Publish(IDomainEvent domainEvent);
}