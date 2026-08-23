using Yes.Application.Services;
using Yes.Shared.Services;

namespace Yes.WebApi.DependencyInjections.User;

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
