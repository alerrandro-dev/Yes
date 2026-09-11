using FluentValidation;
using Yes.Shared.Requests;
using Yes.Shared.Validators;

namespace Yes.WebApi.DependencyInjections;

public static class RegisterValidatorDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddRegisterValidatorDependencyInjection()
        {
            services.AddScoped<IValidator<RegisterRequest>, RegisterValidator>();

            return services;
        }
    }
}
