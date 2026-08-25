using Yes.Application.Services;
using Yes.Shared.Services;

namespace Yes.WebApi.DependencyInjections.ToDoList;

public static class ToDoListServiceDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddToDoListServiceDependencyInjection()
        {
            services.AddScoped<IToDoListService, ToDoListService>();

            return services;
        }
    }
}
