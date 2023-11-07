using System.Linq.Expressions;
using Semicrol.DddTemplate.Core.Products;
using Semicrol.DddTemplate.Core.Shared.Models;

namespace Semicrol.DddTemplate.Core.Shared;

public interface IRepository<TAggregateRoot, TId>
    where TAggregateRoot : AggregateRoot<TId>
    where TId : EntityId
{
    Task<TAggregateRoot> InsertAsync(TAggregateRoot aggregateRoot);

    Task<TAggregateRoot> UpdateAsync(TAggregateRoot aggregateRoot);

    Task DeleteAsync(TAggregateRoot aggregateRoot);

    Task<List<TAggregateRoot>> GetAsync(Expression<Func<TAggregateRoot, bool>> filter = null);

    Task<TAggregateRoot> GetByIdAsync(TId id);
    
    Task SaveChangesAsync();
}