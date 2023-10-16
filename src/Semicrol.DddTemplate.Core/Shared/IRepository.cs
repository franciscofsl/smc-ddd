using System.Linq.Expressions;
using Semicrol.DddTemplate.Core.Orders.ValueObjects;
using Semicrol.DddTemplate.Core.Shared.Models;

namespace Semicrol.DddTemplate.Core.Shared;

public interface IRepository<TAggregateRoot, TId>
    where TAggregateRoot : AgreggateRoot<TId>
    where TId : EntityId
{
    Task<TAggregateRoot> InsertAsync(TAggregateRoot aggregateRoot);

    Task<TAggregateRoot> UpdateAsync(TAggregateRoot aggregateRoot);

    Task DeleteAsync(TAggregateRoot aggregateRoot);

    Task<IList<TAggregateRoot>> GetAsync(Expression<Func<TAggregateRoot, bool>>? filter = null);
    
    Task SaveChangesAsync();
}