using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Semicrol.DddTemplate.Core.Shared;
using Semicrol.DddTemplate.Core.Shared.Models;

namespace Semicrol.DddTemplate.Infrastructure.Data;

public class EfRepository<TAggregateRoot, TId> : IRepository<TAggregateRoot, TId>
    where TAggregateRoot : AggregateRoot<TId>
    where TId : EntityId
{
    public EfRepository(ApplicationDbContext context)
    {
        Context = context;
    }

    protected ApplicationDbContext Context { get; private init; }

    public async Task<TAggregateRoot> InsertAsync(TAggregateRoot aggregateRoot)
    {
        await Context.AddAsync(aggregateRoot);
        return aggregateRoot;
    }

    public Task<TAggregateRoot> UpdateAsync(TAggregateRoot aggregateRoot)
    {
        Context.Update(aggregateRoot);
        return Task.FromResult(aggregateRoot);
    }

    public Task DeleteAsync(TAggregateRoot aggregateRoot)
    {
        Context.Remove(aggregateRoot);
        return Task.CompletedTask;
    }

    public async Task<IList<TAggregateRoot>> GetAsync(Expression<Func<TAggregateRoot, bool>>? filter = null)
    {
        var queryable = Context.Set<TAggregateRoot>().AsQueryable();

        if (filter is not null)
        {
            queryable = queryable.Where(filter);
        }

        return await queryable.ToListAsync();
    }

    public async Task<TAggregateRoot> GetByIdAsync(TId id)
    {
        var queryable = Context.Set<TAggregateRoot>().AsQueryable();
        return await queryable.FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}