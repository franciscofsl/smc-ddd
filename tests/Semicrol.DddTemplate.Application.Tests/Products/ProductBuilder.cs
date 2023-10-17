using Semicrol.DddTemplate.Core.Products;
using Semicrol.DddTemplate.Core.Products.ValueObjects;

namespace Semicrol.DddTemplate.Application.Tests.Products;

public static class ProductBuilder
{
    public static Product Build()
    {
        var productId = new ProductId(Guid.NewGuid());
        var productInfo = ProductInfo.Create("Title", "Description");

        return new Product(productId, productInfo);
    }
}