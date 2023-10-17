namespace Semicrol.DddTemplate.Core.Shared;

public static class GuardClauses
{
    public static TObj NotNull<TObj>(TObj obj, string name)
    {
        if (obj is null)
        {
            throw new ArgumentNullException($"{name} must not be null");
        }
        return obj;
    } 
    
    public static string NotNullOrEmpty(string title, string name)
    {
        NotNull(title, name);
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentException($"{name} must not be empty");
        }

        return title;
    }  
    
    public static int CheckRange(int value, int minValue, int maxValue)
    {
        if (value < minValue || value > maxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(value),
                $"The number must be between {minValue} and {maxValue}.");
        }

        return value;
    }
}