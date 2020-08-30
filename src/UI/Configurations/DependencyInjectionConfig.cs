using BusinessTempus.Interfaces;
using DataTempus.Context;
using DataTempus.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataDbContext>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}
