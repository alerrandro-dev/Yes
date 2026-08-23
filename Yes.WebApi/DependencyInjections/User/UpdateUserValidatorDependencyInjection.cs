using FluentValidation;
using Yes.Shared.Requests.User;
using Yes.Shared.Validators.User;

namespace Yes.WebApi.DependencyInjections.User;

public static class UpdateUserValidatorDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUpdateUserValidatorDependencyInjection()
        {
            services.AddScoped<IValidator<UpdateUserRequest>, UpdateUserValidator>();

            return services;
        }
    }
}
