using Yes.Application.Services;

namespace Yes.WebApi.DependencyInjections;

public static class TokenProviderServiceDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddTokenProviderServiceDependencyInjection()
        {
            services.AddScoped<TokenProviderService>();

            return services;
        }
    }
}
