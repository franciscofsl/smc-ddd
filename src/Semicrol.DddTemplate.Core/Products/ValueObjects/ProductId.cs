using Semicrol.DddTemplate.Core.Shared.Models;

namespace Semicrol.DddTemplate.Core.Products.ValueObjects;

public sealed record ProductId(Guid Id) : EntityId(Id)
{
    public static explicit operator ProductId(Guid id) => new(id);

    public static implicit operator Guid(ProductId id) => id.Id;
}