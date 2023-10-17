using Semicrol.DddTemplate.Core.Shared.Events;

namespace Semicrol.DddTemplate.Core.Products.Events;

public sealed record ProductRated(Product Product) : IDomainEvent;