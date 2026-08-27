using Yes.Application.Services;
using Yes.Shared.Services;

namespace Yes.WebApi.DependencyInjections.Task;

public static class TaskServiceDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddTaskServiceDependencyInjection()
        {
            services.AddScoped<ITaskService, TaskService>();

            return services;
        }
    }
}
