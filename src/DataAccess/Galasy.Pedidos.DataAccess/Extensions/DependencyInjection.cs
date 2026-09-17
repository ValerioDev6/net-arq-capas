using Galasy.Pedidos.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Galasy.Pedidos.DataAccess.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("PedidosDb"));
        });
        
        return services;
    }
}