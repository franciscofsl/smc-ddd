using Microsoft.Extensions.DependencyInjection;
using Semicrol.DddTemplate.Application.Shared.Cqrs.Commands;
using Semicrol.DddTemplate.Application.Shared.Cqrs.Queries;

namespace Semicrol.DddTemplate.Application;

public static class ApplicationServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();
    }
}