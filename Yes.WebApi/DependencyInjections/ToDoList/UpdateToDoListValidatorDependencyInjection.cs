using FluentValidation;
using Yes.Shared.Requests.ToDoList;
using Yes.Shared.Validators.ToDoList;

namespace Yes.WebApi.DependencyInjections.ToDoList;

public static class UpdateToDoListValidatorDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUpdateToDoListValidatorDependencyInjection()
        {
            services.AddScoped<IValidator<UpdateToDoListRequest>, UpdateToDoListValidator>();

            return services;
        }
    }
}
