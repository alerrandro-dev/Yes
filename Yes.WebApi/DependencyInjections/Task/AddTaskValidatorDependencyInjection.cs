using FluentValidation;
using Yes.Shared.Requests.Task;
using Yes.Shared.Validators.Task;

namespace Yes.WebApi.DependencyInjections.Task;

public static class AddTaskValidatorDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddAddTaskValidatorDependencyInjection()
        {
            services.AddScoped<IValidator<AddTaskRequest>, AddTaskValidator>();

            return services;
        }
    }
}
