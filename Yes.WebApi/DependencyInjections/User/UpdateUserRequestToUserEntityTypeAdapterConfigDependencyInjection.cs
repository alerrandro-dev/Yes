using Mapster;
using Yes.Domain.Entities;
using Yes.Shared.Requests.User;

namespace Yes.WebApi.DependencyInjections.User;

public static class UpdateUserRequestToUserEntityTypeAdapterConfigDependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUpdateUserRequestToUserEntityTypeAdapterConfigDependencyInjection()
        {
            var config = new TypeAdapterConfig();
            config.NewConfig<UpdateUserRequest, UserEntity>()
                .IgnoreNullValues(true);

            services.AddKeyedSingleton(config, "UpdateUserRequestToUserEntityTypeAdapterConfig");

            return services;
        }
    }
}
