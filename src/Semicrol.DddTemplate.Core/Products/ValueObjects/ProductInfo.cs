using Semicrol.DddTemplate.Core.Shared.Models;

namespace Semicrol.DddTemplate.Core.Products.ValueObjects;

public sealed record ProductInfo : ValueObject
{
    private ProductInfo()
    {
    }

    public string Title { get; init; }
    
    public string Description { get; init; }

    public static ProductInfo Create(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > 50)
        {
            throw new ArgumentException("Title must be between 1 and 50 characters.");
        }

        if (string.IsNullOrWhiteSpace(description) || description.Length > 2000)
        {
            throw new ArgumentException("Description must be between 1 and 2000 characters.");
        }

        return new ProductInfo
        {
            Description = description,
            Title = title
        };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Title;
        yield return Description;
    }
}