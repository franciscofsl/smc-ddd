using Microsoft.Extensions.DependencyInjection;
using Semicrol.DddTemplate.Application.Cqrs.Commands;
using Semicrol.DddTemplate.Application.Cqrs.Queries;

namespace Semicrol.DddTemplate.Application;

public static class ApplicationServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();
    }
}