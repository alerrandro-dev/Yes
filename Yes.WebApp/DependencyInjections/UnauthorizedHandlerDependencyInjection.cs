using Yes.WebApp.Handlers;

namespace Yes.WebApp.DependencyInjections;

public static class UnauthorizedHandlerDependencyInjection
{
    extension (IServiceCollection services)
    {
        public IServiceCollection AddUnauthorizedHandlerDependencyInjection()
        {
            services.AddTransient<UnauthorizedHandler>();

            return services;
        }
    }
}
