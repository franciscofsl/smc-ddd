using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Semicrol.DddTemplate.Core.Shared;
using Semicrol.DddTemplate.Infrastructure.Data;

namespace Semicrol.DddTemplate.Infrastructure;

public static class InfrastructureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRepository<,>), typeof(EfRepository<,>)); 
        
        var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));
    }
    
}