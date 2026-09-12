using Yes.Shared.Services;
using Yes.WebApp.Services;

namespace Yes.WebApp.DependencyInjections;

public static class AuthenticationServiceDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddAuthenticationServiceDependencyInjection()
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }
    }
}
