using System.Reflection;
using Semicrol.DddTemplate.Core.Shared.Models;

namespace Semicrol.DddTemplate.Core.Tests.Shared;

public static class ValueObjectExtensions
{
    public static object[] InvokeGetAtomicValues<TValueObject>(this TValueObject valueObject) where TValueObject : ValueObject
    { 
        var methodInfo = typeof(TValueObject)
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(m => m.Name == "GetAtomicValues")
            .FirstOrDefault();

        if (methodInfo == null)
        {
            throw new InvalidOperationException("GetAtomicValues method not found.");
        }

        var result = methodInfo.Invoke(valueObject, null) as IEnumerable<object>;

        return result?.ToArray();
    }
}