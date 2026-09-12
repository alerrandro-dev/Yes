using Mapster;
using Yes.Domain.Entities;
using Yes.Shared.Requests.Task;

namespace Yes.WebApi.DependencyInjections.Task;

public static class UpdateTaskRequestToTaskEntityTypeAdapterConfigDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUpdateTaskRequestToTaskEntityTypeAdapterConfigDependencyInjection()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<UpdateTaskRequest, TaskEntity>()
                .IgnoreNullValues(true);

            services.AddKeyedSingleton(config, "UpdateTaskRequestToTaskEntityTypeAdapterConfig");

            return services;
        }
    }
}
