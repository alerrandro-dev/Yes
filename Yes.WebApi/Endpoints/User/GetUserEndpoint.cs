using Yes.Shared.Errors.Entity;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.User;

public static class GetUserEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapGetUserEndpoint()
        {
            routeBuilder.MapGet("", async (IUserService service) =>
            {
                var result = await service.GetAsync();

                return result switch
                {
                    UserResponse response => Results.Ok(response),
                    EntityNotFoundError entityNotFoundError => Results.NotFound(entityNotFoundError)
                };
            }).RequireAuthorization()
                .WithName("GetUser");

            return routeBuilder;
        }
    }
}
