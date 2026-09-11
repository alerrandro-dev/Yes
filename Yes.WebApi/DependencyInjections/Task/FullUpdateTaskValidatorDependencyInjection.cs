using FluentValidation;
using Yes.Shared.Requests.Task;
using Yes.Shared.Validators.Task;

namespace Yes.WebApi.DependencyInjections.Task;

public static class FullUpdateTaskValidatorDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddFullUpdateTaskValidatorDependencyInjection()
        {
            services.AddKeyedScoped<IValidator<UpdateTaskRequest>, FullUpdateTaskValidator>("FullUpdateTaskValidator");

            return services;
        }
    }
}
