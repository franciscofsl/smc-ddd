using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Semicrol.DddTemplate.Core.Products;
using Semicrol.DddTemplate.Core.Products.ValueObjects;

namespace Semicrol.DddTemplate.Infrastructure.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(x => x.Id, _ => (ProductId)_)
            .IsRequired();

        builder.OwnsOne(_ => _.Information, ownedNavigationBuilder => { ownedNavigationBuilder.ToJson(); });
        builder.OwnsOne(_ => _.Price, ownedNavigationBuilder => { ownedNavigationBuilder.ToJson(); });

        builder.OwnsOne(_ => _.Ratings, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.ToJson();
            ownedNavigationBuilder.OwnsMany(ratings => ratings.Values);
        });

        builder.Ignore(_ => _.Events);
    }
}