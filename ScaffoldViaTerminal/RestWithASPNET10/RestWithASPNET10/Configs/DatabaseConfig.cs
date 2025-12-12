using RestWithASPNET10.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace RestWithASPNET10.Configs
{
    public static class DatabaseConfig
    {   
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings : DefaultConnection"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            }

            services.AddDbContext<MSSQLContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

    }
}
