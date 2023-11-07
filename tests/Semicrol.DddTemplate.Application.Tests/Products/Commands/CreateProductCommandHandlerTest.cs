using Castle.Components.DictionaryAdapter;
using Moq;
using NSubstitute;
using Semicrol.DddTemplate.Application.Products.Commands.CreateProduct;
using Semicrol.DddTemplate.Core.Products;
using Shouldly;

namespace Semicrol.DddTemplate.Application.Tests.Products.Commands;

public class CreateProductCommandHandlerTest
{
    [Fact]
    public async Task Handle_CreateProductCommand_Should_Return_Product()
    {
        var repository = Substitute.For<IProductRepository>();
        
        var handler = new CreateProductCommandHandler(repository);
        var command = new CreateProductCommand
        {
            Title = "Test Product",
            Description = "This is a test product."
        };

        var result = await handler.Handle(command);

        result.ShouldNotBeNull();
        result.Information.Title.ShouldBe("Test Product");
        result.Information.Description.ShouldBe("This is a test product.");
    } 
    
    [Fact]
    public async Task Handle_CreateProductCommand_Should_Save_Changes_In_Repository()
    {
        var repository = Substitute.For<IProductRepository>();
        var handler = new CreateProductCommandHandler(repository);
        var command = new CreateProductCommand
        {
            Title = "Test Product",
            Description = "This is a test product."
        };

        await handler.Handle(command);
    }
} 