using Semicrol.DddTemplate.Core.Shared.Models;

namespace Semicrol.DddTemplate.Core.Products.ValueObjects;

public sealed record Price : ValueObject
{
    private const int DefaultVat = 21;

    public static Price Empty => Create(0, DefaultVat);

    private Price()
    {
    }

    public decimal? Value { get; init; }

    public int Vat { get; init; }

    public static Price Create(decimal? value, int vat)
    {
        if (vat < 0)
        {
            throw new ArgumentException("VAT cannot be negative.");
        }

        return new Price
        {
            Value = value,
            Vat = vat
        };
    }

    public decimal Total()
    {
        if (!Value.HasValue)
        {
            return 0;
        }

        return Value.Value + (Value.Value * Vat / 100m);
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
        yield return Vat;
    }
}