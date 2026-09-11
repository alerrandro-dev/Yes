using Yes.Application.Services;
using Yes.Shared.Services;

namespace Yes.WebApi.DependencyInjections;

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
