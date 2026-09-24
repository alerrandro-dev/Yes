using Yes.Shared.Contexts;
using Yes.WebApp.Contexts;

namespace Yes.WebApp.DependencyInjections.User;

public static class UserContextDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUserContextDependencyInjection()
        {
            services.AddSingleton<IUserContext, UserContext>();

            return services;
        }
    }
}
