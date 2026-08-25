using Yes.Domain.Repositories;
using Yes.Infrastructure.Repositories;

namespace Yes.WebApi.DependencyInjections.ToDoList;

public static class ToDoListRepositoryDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddToDoListRepositoryDependencyInjection()
        {
            services.AddScoped<IToDoListRepository, ToDoListRepository>();

            return services;
        }
    }
}
