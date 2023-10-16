using Semicrol.DddTemplate.Core.Shared.Events;

namespace Semicrol.DddTemplate.Core.Shared.Models;

public interface IEntityWithDomainEvents
{
    IReadOnlyList<IDomainEvent> Events { get; }

    void ClearDomainEvents();
}