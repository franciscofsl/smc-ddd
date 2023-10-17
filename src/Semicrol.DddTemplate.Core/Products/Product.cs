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
    }

    public Product(ProductId id, ProductInfo info)
        : base(id)
    {
        Information = GuardClauses.NotNull(info, nameof(info));
        Price = Price.Empty;
        Ratings = Ratings.Empty;
    }

    public ProductInfo Information { get; private set; }

    public Price Price { get; private set; }

    public Ratings Ratings { get; private set; }

    public ProductInfo ChangeInfo(string title, string description)
    {
        Information = ProductInfo.Create(title, description);
        return Information;
    }

    public Price ChangePrice(decimal? value, int vat)
    {
        Price = Price.Create(value, vat);
        return Price;
    }

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