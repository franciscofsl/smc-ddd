namespace Semicrol.DddTemplate.Core.Shared.Events;

public interface IDomainEventHandler<in TEvent> where TEvent : IDomainEvent
{
    Task Handle(TEvent domainEvent, CancellationToken token = default);
}