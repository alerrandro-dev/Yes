using FluentValidation;
using Yes.Shared.Requests.User;
using Yes.Shared.Validators.User;

namespace Yes.WebApi.DependencyInjections.User;

public static class FullUpdateUserValidatorDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddFullUpdateUserValidatorDependencyInjection()
        {
            services.AddKeyedScoped<IValidator<UpdateUserRequest>, FullUpdateUserValidator>("FullUpdateUserValidator");

            return services;
        }
    }
}
