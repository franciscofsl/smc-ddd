using Semicrol.DddTemplate.Core.Orders.ValueObjects;
using Semicrol.DddTemplate.Core.Shared.Events;

namespace Semicrol.DddTemplate.Core.Shared.Models;

public class AgreggateRoot<TId> where TId : EntityId
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public TId Id { get; protected init; }

    public IReadOnlyList<IDomainEvent> Events => _domainEvents.AsReadOnly();

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}