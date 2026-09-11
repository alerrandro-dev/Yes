using FluentValidation;
using Yes.Shared.Requests.ToDoList;
using Yes.Shared.Validators.ToDoList;

namespace Yes.WebApi.DependencyInjections.ToDoList;

public static class FullUpdateToDoListValidatorDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddFullUpdateToDoListValidatorDependencyInjection()
        {
            services.AddScoped<IValidator<UpdateToDoListRequest>, FullUpdateToDoListValidator>();

            return services;
        }
    }
}
