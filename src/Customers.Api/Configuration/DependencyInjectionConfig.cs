using Customers.Api.Data.Repositories;
using Customers.Api.Models;

namespace Customers.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRepository<Customer>, CustomerRepository>();
        }
    }
}