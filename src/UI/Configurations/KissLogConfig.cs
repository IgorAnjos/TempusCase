using KissLog;
using KissLog.Apis.v1.Listeners;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UI.Configurations
{
    public static class KissLogConfig
    {
        [System.Obsolete]
        public static void RegisterKissLogListeners(IConfiguration configuration)
        {
            KissLogConfiguration.Listeners.Add(new KissLogApiListener(
                configuration["KissLog.OrganizationId"],
                configuration["KissLog.ApplicationId"],
                configuration["KissLog.Environment"]
            ));
        }

        public static IServiceCollection RegisterKissLogILogger(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ILogger>((context) =>
            {
                return Logger.Factory.Get();
            });

            return services;
        }

    }
}