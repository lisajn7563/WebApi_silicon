using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApi_silicon.Configurations;

public static class DbContextRegistation
{
    public static void RegisterDbConxets( this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApiContext>(x => x.UseSqlServer(config.GetConnectionString("SqlServer")));
    }
}
