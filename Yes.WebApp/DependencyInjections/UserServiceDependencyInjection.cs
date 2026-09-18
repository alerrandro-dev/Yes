using Yes.Shared.Services;
using Yes.WebApp.Services;

namespace Yes.WebApp.DependencyInjections;

public static class UserServiceDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUserServiceDependencyInjection()
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
