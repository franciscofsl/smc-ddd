using Semicrol.DddTemplate.Core.Shared.Models;

namespace Semicrol.DddTemplate.Core.Common.ValueObjects;

public record Ratings : ValueObject
{
    private readonly List<Rating> _values = new();

    public static Ratings Empty => new();

    private Ratings()
    {
    }

    public virtual IReadOnlyCollection<Rating> Values => _values.AsReadOnly();

    public Rating AddRating(string user, int value)
    {
        if (UserHasRating(user))
        {
            throw new ApplicationException("The user has already rated the product.");
        }

        var rating = Rating.Create(user, value);
        _values.Add(rating);
        return rating;
    }

    public bool RemoveRating(string user)
    {
        if (UserHasRating(user))
        {
            _values.RemoveAll(_ => _.User == user);
            return true;
        }

        return false;
    }

    public bool UserHasRating(string user) => _values.Exists(_ => _.User == user);

    protected override IEnumerable<object> GetAtomicValues()
    {
        return _values;
    }
}