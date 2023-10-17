using Semicrol.DddTemplate.Core.Products;
using Semicrol.DddTemplate.Core.Products.ValueObjects;

namespace Semicrol.DddTemplate.Infrastructure.Data.Repositories;

public class ProductRepository : EfRepository<Product, ProductId>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}