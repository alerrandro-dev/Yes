using FluentValidation;
using Yes.Shared.Requests.User;
using Yes.Shared.Validators.User;

namespace Yes.WebApi.DependencyInjections.User;

public static class PartialUpdateUserValidatorDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddPartialUpdateUserValidatorDependencyInjection()
        {
            services.AddKeyedScoped<IValidator<UpdateUserRequest>, PartialUpdateUserValidator>("PartialUpdateUserValidator");

            return services;
        }
    }
}
