using Semicrol.DddTemplate.Core.Products.ValueObjects;
using Semicrol.DddTemplate.Core.Tests.Shared;
using Shouldly;

namespace Semicrol.DddTemplate.Core.Tests.Products.ValueObjects;

public class PriceTest
{
    [Fact]
    public void Create_Price_With_Valid_Arguments_Should_Not_Throw_Exception()
    {
        const decimal validValue = 100;
        const int validVat = 10;

        Should.NotThrow(() => Price.Create(validValue, validVat));
    }

    [Fact]
    public void Create_Price_With_Negative_Vat_Should_Throw_Argument_Exception()
    {
        const decimal validValue = 100;
        const int negativeVat = -10;

        Should.Throw<ArgumentException>(() => Price.Create(validValue, negativeVat))
            .Message.ShouldContain("VAT cannot be negative.");
    }

    [Fact]
    public void Total_Price_With_Non_Null_Value_Should_Calculate_Total_Correctly()
    {
        var price = Price.Create(100, 10);

        var total = price.Total();

        total.ShouldBe(110);
    }

    [Fact]
    public void Total_Price_With_Null_Value_Should_Return_Zero()
    {
        var price = Price.Create(null, 10);

        var total = price.Total();

        total.ShouldBe(0);
    }

    [Fact]
    public void Get_Atomic_Values_Should_Return_Correct_Values()
    {
        var price = Price.Create(100, 10);

        var atomicValues = price.InvokeGetAtomicValues();

        atomicValues.ShouldNotBeNull();
        atomicValues.ShouldBe(new object[] { 100m, 10 });
    }
}