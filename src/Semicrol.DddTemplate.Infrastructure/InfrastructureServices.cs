using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Semicrol.DddTemplate.Application.Products.Events;
using Semicrol.DddTemplate.Core.Products;
using Semicrol.DddTemplate.Core.Products.Events;
using Semicrol.DddTemplate.Core.Shared;
using Semicrol.DddTemplate.Core.Shared.Events;
using Semicrol.DddTemplate.Infrastructure.Data;
using Semicrol.DddTemplate.Infrastructure.Data.Repositories;

namespace Semicrol.DddTemplate.Infrastructure;

public static class InfrastructureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<,>), typeof(EfRepository<,>));
        services.AddTransient(typeof(IProductRepository), typeof(ProductRepository));

        var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));

        services.AddTransient(typeof(IDomainEventHandler<ProductRated>), typeof(ProductRatedEventHandler));
    }
}