using FluentValidation;
using Yes.Shared.Requests;
using Yes.Shared.Validators;

namespace Yes.WebApp.DependencyInjections;

public static class LoginValidatorDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddLoginValidatorDependencyInjection()
        {
            services.AddScoped<IValidator<LoginRequest>, LoginValidator>();

            return services;
        }
    }
}
