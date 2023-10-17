using Semicrol.DddTemplate.Core.Products;
using Semicrol.DddTemplate.Core.Products.ValueObjects;
using Shouldly;

namespace Semicrol.DddTemplate.Core.Tests.Products;

public class ProductTest
{
    [Fact]
    public void Create_Product_With_Valid_Arguments_Should_Not_Throw_Exception()
    {
        var productId = new ProductId(Guid.NewGuid());
        var productInfo = ProductInfo.Create("Valid Title", "Valid Description");
        var price = Price.Create(100, 10);

        Should.NotThrow(() => new Product(productId, productInfo));
    }

    [Fact]
    public void ChangeInfo_Should_Update_Information()
    {
        var product = CreateSampleProduct();
        var newInfo = product.ChangeInfo("New Title", "New Description");

        newInfo.Title.ShouldBe("New Title");
        newInfo.Description.ShouldBe("New Description");
    }

    [Fact]
    public void ChangePrice_Should_Update_Price()
    {
        var product = CreateSampleProduct();
        var newPrice = product.ChangePrice(200, 15);

        newPrice.Value.ShouldBe(200);
        newPrice.Vat.ShouldBe(15);
    }

    [Fact]
    public void Rate_Should_Add_Rating()
    {
        var product = CreateSampleProduct();
        var rating = product.Rate("User1", 4);

        product.Ratings.Values.Count.ShouldBe(1);
        product.Ratings.Values.ShouldContain(rating);
    }

    [Fact]
    public void UnRate_Should_Remove_Rating()
    {
        var product = CreateSampleProduct();
        product.Rate("User1", 4);

        product.UnRate("User1");

        product.Ratings.Values.Count.ShouldBe(0);
    }

    private static Product CreateSampleProduct()
    {
        var productId = new ProductId(Guid.NewGuid());
        var productInfo = ProductInfo.Create("Title", "Description");

        return new Product(productId, productInfo);
    }
}