using Semicrol.DddTemplate.Core.Common.ValueObjects;
using Semicrol.DddTemplate.Core.Products.Events;
using Semicrol.DddTemplate.Core.Products.ValueObjects;
using Semicrol.DddTemplate.Core.Shared;
using Semicrol.DddTemplate.Core.Shared.Models;

namespace Semicrol.DddTemplate.Core.Products;

public class Product : AggregateRoot<ProductId>
{
    private Product()
    {
        /* For ORM */
    }

    public Product(ProductId id, ProductInfo info)
        : base(id)
    {
        Information = GuardClauses.NotNull(info, nameof(info));
        Ratings = Ratings.Empty;
    }

    public ProductInfo Information { get; private init; }

    public Ratings Ratings { get; private init; }

    public Rating Rate(string user, int value)
    {
        var rating = Ratings.AddRating(user, value);

        RaiseDomainEvent(new ProductRated(this));
        
        return rating;
    }

    public void UnRate(string user)
    {
        Ratings.RemoveRating(user);
    }
}