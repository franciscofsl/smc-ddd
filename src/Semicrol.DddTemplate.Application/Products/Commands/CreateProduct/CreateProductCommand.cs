using Semicrol.DddTemplate.Application.Shared.Cqrs.Commands;
using Semicrol.DddTemplate.Core.Products;

namespace Semicrol.DddTemplate.Application.Products.Commands.CreateProduct;

public class CreateProductCommand : ICommand<Product>
{
    public string Title { get; set; }
    
    public string Description { get; set; }
}