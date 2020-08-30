using Microsoft.Extensions.DependencyInjection;

namespace UI.Configurations
{
    public static class AuthorizationConfig
    {
        public static IServiceCollection AddAuthorizationConfig(this IServiceCollection services)
        {
            //Utilizar para claims roles etc...
            return services;
        }
    }
}
