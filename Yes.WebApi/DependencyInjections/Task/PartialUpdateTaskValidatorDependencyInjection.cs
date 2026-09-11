using FluentValidation;
using Yes.Shared.Requests.Task;
using Yes.Shared.Validators.Task;

namespace Yes.WebApi.DependencyInjections.Task;

public static class PartialUpdateTaskValidatorDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddPartialUpdateTaskValidatorDependencyInjection()
        {
            services.AddKeyedScoped<IValidator<UpdateTaskRequest>, PartialUpdateTaskValidator>("PartialUpdateTaskValidator");

            return services;
        }
    }
}
