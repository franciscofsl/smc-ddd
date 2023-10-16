using Microsoft.EntityFrameworkCore;
using Semicrol.DddTemplate.Application.Contracts;
using Semicrol.DddTemplate.Core.Shared.Models;

namespace Semicrol.DddTemplate.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    private readonly IDomainEventPublisher _publisher;

    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions options, IDomainEventPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=DddTemplate;User=sa;Password=Semicrol_10;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        await DispatchDomainEvents();
        return result;
    }

    public override int SaveChanges()
    {
        var result = base.SaveChanges();
        DispatchDomainEvents().GetAwaiter().GetResult();
        return result;
    }

    private async Task DispatchDomainEvents()
    {
        var domainEventEntities = ChangeTracker.Entries<IEntityWithDomainEvents>()
            .Select(po => po.Entity)
            .Where(po => po.Events.Any())
            .ToArray();

        foreach (var entity in domainEventEntities)
        {
            foreach (var entityEvents in entity.Events)
            {
                await _publisher.Publish(entityEvents);
            }

            entity.ClearDomainEvents();
        }
    }
}