using Semicrol.DddTemplate.Core.Shared;
using Semicrol.DddTemplate.Core.Shared.Models;

namespace Semicrol.DddTemplate.Core.Common.ValueObjects;

public sealed record Rating : ValueObject
{
    private const int MinRatingValue = 0;
    private const int MaxRatingValue = 5;

    private Rating()
    {
    }

    public static Rating Create(string user, int value)
    {
        return new Rating
        {
            User = GuardClauses.NotNullOrEmpty(user, nameof(user)),
            Value = GuardClauses.CheckRange(value, MinRatingValue, MaxRatingValue),
            Date = DateTime.Now
        };
    }

    public string User { get; private init; }

    public int Value { get; private init; }

    public DateTime Date { get; private init; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return User;
        yield return Value;
        yield return Date;
    }
}