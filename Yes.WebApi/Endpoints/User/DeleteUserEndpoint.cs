using Yes.Shared.Errors.Entity;
using Yes.Shared.Results;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.User;

public static class DeleteUserEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapDeleteUserEndpoint()
        {
            routeBuilder.MapDelete("", async (IUserService service) =>
            {
                var result = await service.DeleteAsync();

                return result switch
                {
                    Success success => Results.NoContent(),
                    EntityNotFoundError entityNotFoundError => Results.NotFound(entityNotFoundError)
                };
            }).RequireAuthorization()
                .WithName("DeleteUser");

            return routeBuilder;
        }
    }
}
