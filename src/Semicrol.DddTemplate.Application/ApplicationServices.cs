using Microsoft.Extensions.DependencyInjection;
using Semicrol.DddTemplate.Application.Products.Commands.CreateProduct;
using Semicrol.DddTemplate.Application.Products.Commands.RateProduct;
using Semicrol.DddTemplate.Application.Products.Queries.GetProductRatings;
using Semicrol.DddTemplate.Application.Shared.Cqrs.Commands;
using Semicrol.DddTemplate.Application.Shared.Cqrs.Queries;
using Semicrol.DddTemplate.Core.Common.ValueObjects;
using Semicrol.DddTemplate.Core.Products;

namespace Semicrol.DddTemplate.Application;

public static class ApplicationServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();

        services.AddTransient<ICommandHandler<CreateProductCommand, Product>, CreateProductCommandHandler>();
        services.AddTransient<ICommandHandler<RateProductCommand, Rating>, RateProductCommandHandler>();
        services.AddTransient<IQueryHandler<GetProductRatingQuery, Ratings>, GetProductRatingsQueryHandler>();
    }
}