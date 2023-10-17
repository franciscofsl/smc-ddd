using Semicrol.DddTemplate.Core.Common.ValueObjects;
using Semicrol.DddTemplate.Core.Tests.Shared;
using Shouldly;

namespace Semicrol.DddTemplate.Core.Tests.Common.ValueObjects;

public class RatingTest
{
    [Fact]
    public void Create_Rating_With_Valid_Arguments_Should_Not_Throw_Exception()
    {
        const string validUser = "ValidUser";
        const int validValue = 3;

        Should.NotThrow(() => Rating.Create(validUser, validValue));
    }

    [Fact]
    public void Create_Rating_With_Null_User_Should_Throw_Argument_Exception()
    {
        const string nullUser = null;
        const int validValue = 3;

        Should.Throw<ArgumentException>(() => Rating.Create(nullUser, validValue))
            .Message.ShouldContain("user must not be null");
    }

    [Fact]
    public void Create_Rating_With_Empty_User_Should_Throw_Argument_Exception()
    {
        const string emptyUser = "";
        const int validValue = 3;

        Should.Throw<ArgumentException>(() => Rating.Create(emptyUser, validValue))
            .Message.ShouldContain("user must not be empty");
    }

    [Fact]
    public void Create_Rating_With_Invalid_Value_Should_Throw_Argument_Exception()
    {
        const string validUser = "ValidUser";
        const int invalidValue = -1;

        Should.Throw<ArgumentException>(() => Rating.Create(validUser, invalidValue))
            .Message.ShouldContain("The number must be between 0 and 5. (Parameter 'value')");
    }

    [Fact]
    public void Create_Rating_With_Value_Above_Max_Should_Throw_Argument_Exception()
    {
        const string validUser = "ValidUser";
        const int valueAboveMax = 6;

        Should.Throw<ArgumentException>(() => Rating.Create(validUser, valueAboveMax))
            .Message.ShouldContain("The number must be between 0 and 5. (Parameter 'value')");
    }

    [Fact]
    public void Get_Atomic_Values_Should_Return_Correct_Values()
    {
        var rating = Rating.Create("ValidUser", 3);

        var atomicValues = rating.InvokeGetAtomicValues();

        atomicValues.ShouldNotBeNull();
        atomicValues.ShouldBe(new object[] { "ValidUser", 3, rating.Date });
    }
}