using System.Reflection;
using Customers.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Customers.Api.Configuration
{
    public static class DatabaseConfig
    {

        public static void AddDatabaseConfig(this IServiceCollection services, WebApplicationBuilder builder)
        {   
            var configuration = GetConfiguration(builder);

            services.AddDbContext<CustomerContext>(options => 
                options.UseSqlite(
                    configuration.GetConnectionString("DefaultConnection"),  
                    b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)));
        }

        private static IConfiguration GetConfiguration(WebApplicationBuilder builder)
        {
            return new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }
        
    }
}