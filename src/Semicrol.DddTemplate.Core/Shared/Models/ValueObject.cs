namespace Semicrol.DddTemplate.Core.Shared.Models;

public abstract record ValueObject : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object> GetAtomicValues();

    public override int GetHashCode()
    {
        return GetAtomicValues().Aggregate(default(int), HashCode.Combine);
    }

    private bool ValuesAreEqual(ValueObject other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    public virtual bool Equals(ValueObject? other)
    {
        return other is not null && ValuesAreEqual(other);
    }
}