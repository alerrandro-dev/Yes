using FluentValidation;
using Yes.Shared.Requests.Task;
using Yes.Shared.Validators.Task;

namespace Yes.WebApi.DependencyInjections.Task;

public static class UpdateTaskValidatorDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUpdateTaskValidatorDependencyInjection()
        {
            services.AddScoped<IValidator<UpdateTaskRequest>, UpdateTaskValidator>();

            return services;
        }
    }
}
