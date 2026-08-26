using Yes.Shared.Errors.Entity;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.User;

public static class GetUserByIdEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapGetUserByIdEndpoint()
        {
            routeBuilder.MapGet("{id:guid}", async (IUserService service, Guid id) =>
            {
                var result = await service.GetByIdAsync(id);

                return result switch
                {
                    UserResponse response => Results.Ok(response),
                    EntityNotFoundError entityNotFound => Results.NotFound(entityNotFound)
                };
            }).WithName("GetUserById");

            return routeBuilder;
        }
    }
}
