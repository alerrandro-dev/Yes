using Yes.Domain.Repositories;
using Yes.Infrastructure.Repositories;

namespace Yes.WebApi.DependencyInjections.Task;

public static class TaskRepositoryDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddTaskRepositoryDependencyInjection()
        {
            services.AddScoped<ITaskRepository, TaskRepository>();

            return services;
        }
    }
}
