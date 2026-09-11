using Yes.Shared.Contexts;
using Yes.WebApi.Contexts;

namespace Yes.WebApi.DependencyInjections.User;

public static class UserContextDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUserContextDependencyInjection()
        {
            services.AddScoped<IUserContext, UserContext>();

            return services;
        }
    }
}
