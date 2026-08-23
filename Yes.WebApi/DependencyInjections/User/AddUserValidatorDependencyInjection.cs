using FluentValidation;
using Yes.Shared.Requests.User;
using Yes.Shared.Validators.User;

namespace Yes.WebApi.DependencyInjections.User;

public static class AddUserValidatorDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddAddUserValidatorDependencyInjection()
        {
            services.AddScoped<IValidator<AddUserRequest>, AddUserValidator>();

            return services;
        }
    }
}
