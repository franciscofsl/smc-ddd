using System.Linq.Expressions;
using Semicrol.DddTemplate.Core.Products;
using Semicrol.DddTemplate.Core.Products.ValueObjects;

namespace Semicrol.DddTemplate.Application.Tests.Products.Queries;

public class ProductRepositoryFake : IProductRepository
{
    private readonly Dictionary<ProductId, Product> _products = new();

    public Task<Product> InsertAsync(Product product)
    {
        _products.TryAdd(product.Id, product);

        return Task.FromResult(product);
    }

    public Task<Product> UpdateAsync(Product product)
    {
        if (_products.TryGetValue(product.Id, out _))
        {
            _products[product.Id] = product;
        }

        return Task.FromResult(product);
    }

    public Task DeleteAsync(Product product)
    {
        _products.Remove(product.Id);
        return Task.CompletedTask;
    }

    public Task<List<Product>> GetAsync(Expression<Func<Product, bool>> filter = null)
    {
        var products = filter is not null
            ? _products.Values.Where(filter.Compile()).ToList()
            : _products.Values.ToList();

        return Task.FromResult(products);
    }

    public Task<Product> GetByIdAsync(ProductId id)
    {
        _products.TryGetValue(id, out var product);

        return Task.FromResult(product);
    }

    public Task SaveChangesAsync()
    {
        return Task.CompletedTask;
    }
}