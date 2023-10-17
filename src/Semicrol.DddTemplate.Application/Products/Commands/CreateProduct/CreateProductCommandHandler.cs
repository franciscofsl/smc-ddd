using Semicrol.DddTemplate.Application.Shared.Cqrs.Commands;
using Semicrol.DddTemplate.Core.Products;
using Semicrol.DddTemplate.Core.Products.ValueObjects;

namespace Semicrol.DddTemplate.Application.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Product>
{
    private readonly IProductRepository _repository;

    public CreateProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> Handle(CreateProductCommand command, CancellationToken token = default)
    {
        var productId = new ProductId(Guid.NewGuid());
        var productInfo = ProductInfo.Create(command.Title, command.Description);

        var product = new Product(productId, productInfo);

        await _repository.InsertAsync(product);
        await _repository.SaveChangesAsync();

        return product;
    }
}