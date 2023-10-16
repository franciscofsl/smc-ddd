namespace Semicrol.DddTemplate.Core.Shared.Events;

public class DomainEventException : Exception
{
    public DomainEventException(string message)
        : base(message)
    {
    }
}