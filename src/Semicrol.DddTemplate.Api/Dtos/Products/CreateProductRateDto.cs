namespace Semicrol.DddTemplate.Api.Dtos.Products;

public class CreateProductRateDto
{
    public Guid ProductId { get; set; }
    public string User { get; set; }
    public int Value { get; set; }
}