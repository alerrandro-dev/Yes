using Yes.Domain.Repositories;
using Yes.Infrastructure.Repositories;

namespace Yes.WebApi.DependencyInjections.User;

public static class UserRepositoryDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUserRepositoryDependencyInjection()
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
