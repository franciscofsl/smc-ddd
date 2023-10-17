using Semicrol.DddTemplate.Core.Products.ValueObjects;
using Semicrol.DddTemplate.Core.Tests.Shared;
using Shouldly;

namespace Semicrol.DddTemplate.Core.Tests.Products.ValueObjects;

public class ProductInfoTest
{
    [Fact]
    public void Create_ProductInfo_With_Valid_Arguments_Should_Not_Throw_Exception()
    {
        const string validTitle = "Valid Title";
        const string validDescription = "Valid Description";

        Should.NotThrow(() => ProductInfo.Create(validTitle, validDescription));
    }

    [Fact]
    public void Create_ProductInfo_With_Invalid_Title_Should_Throw_Argument_Exception()
    {
        const string invalidTitle = "";

        Should.Throw<ArgumentException>(() => ProductInfo.Create(invalidTitle, "Valid Description"))
            .Message.ShouldContain("Title must be between 1 and 50 characters.");
    }

    [Fact]
    public void Create_ProductInfo_With_Invalid_Description_Should_Throw_Argument_Exception()
    {
        const string validTitle = "Valid Title";
        var invalidDescription = new string('A', 2001);

        Should.Throw<ArgumentException>(() => ProductInfo.Create(validTitle, invalidDescription))
            .Message.ShouldContain("Description must be between 1 and 2000 characters.");
    }

    [Fact]
    public void Get_Atomic_Values_Should_Return_Correct_Values()
    {
        var productInfo = ProductInfo.Create("Valid Title", "Valid Description");

        var atomicValues = productInfo.InvokeGetAtomicValues();

        atomicValues.ShouldNotBeNull();
        atomicValues.ShouldBe(new object[]
        {
            "Valid Title", "Valid Description"
        });
    }
}