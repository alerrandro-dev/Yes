using Yes.Application.Services;

namespace Yes.WebApi.DependencyInjections;

public static class CookieServiceDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddCookieServiceDependencyInjection()
        {
            services.AddScoped<CookieService>();

            return services;
        }
    }
}
