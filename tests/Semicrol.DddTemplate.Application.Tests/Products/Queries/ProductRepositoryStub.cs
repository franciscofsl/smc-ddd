using System.Linq.Expressions;
using Semicrol.DddTemplate.Core.Products;
using Semicrol.DddTemplate.Core.Products.ValueObjects;

namespace Semicrol.DddTemplate.Application.Tests.Products.Queries;

public class ProductRepositoryStub : IProductRepository
{
    public Task<Product> InsertAsync(Product aggregateRoot)
    {
        return Task.FromResult(aggregateRoot);
    }

    public Task<Product> UpdateAsync(Product aggregateRoot)
    {
        return Task.FromResult(aggregateRoot);
    }

    public Task DeleteAsync(Product aggregateRoot)
    {
        return Task.CompletedTask;
    }

    public Task<List<Product>> GetAsync(Expression<Func<Product, bool>> filter = null)
    {
        var products = Enumerable
            .Range(0, 100)
            .Select(_ => ProductBuilder.Build())
            .ToList();

        return Task.FromResult(products);
    }

    public Task<Product> GetByIdAsync(ProductId id)
    {
        var productInfo = ProductInfo.Create("Title", "Description");
        
        var product = new Product(id, productInfo);

        product.Ratings.AddRating("test-user", 5);

        return Task.FromResult(product);
    }

    public Task SaveChangesAsync()
    {
        return Task.CompletedTask;
    }
}