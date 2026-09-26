using Yes.WebApp.Handlers;

namespace Yes.WebApp.DependencyInjections;

public static class BrowserCredentialsHandlerDependencyInjection
{
    extension (IServiceCollection services)
    {
        public IServiceCollection AddBrowserCredentialsHandlerDependencyInjection()
        {
            services.AddTransient<BrowserCredentialsHandler>();
            
            return services;
        }
    }
}
