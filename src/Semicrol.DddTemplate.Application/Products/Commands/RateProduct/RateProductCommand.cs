using Semicrol.DddTemplate.Application.Shared.Cqrs.Commands;
using Semicrol.DddTemplate.Core.Common.ValueObjects;
using Semicrol.DddTemplate.Core.Products;

namespace Semicrol.DddTemplate.Application.Products.Commands.RateProduct;

public class RateProductCommand : ICommandRequest<Rating>
{
    public Guid ProductId { get; set; }
    
    public string User { get; set; }
    
    public int Value { get; set; }
}