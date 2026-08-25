using FluentValidation;
using Yes.Shared.Requests.ToDoList;
using Yes.Shared.Validators.ToDoList;

namespace Yes.WebApi.DependencyInjections.ToDoList;

public static class AddToDoListValidatorDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddAddToDoListValidatorDependencyInjection()
        {
            services.AddScoped<IValidator<AddToDoListRequest>, AddToDoListValidator>();

            return services;
        }
    }
}
