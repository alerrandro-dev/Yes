using Yes.Shared.Errors.Entity;
using Yes.Shared.Results;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.User;

public static class DeleteUserByIdEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapDeleteUserByIdEndpoint()
        {
            routeBuilder.MapDelete("{id:guid}", async (IUserService service, Guid id) =>
            {
                var result = await service.DeleteByIdAsync(id);

                return result switch
                {
                    Success success => Results.NoContent(),
                    EntityNotFoundError entityNotFound => Results.NotFound(entityNotFound)
                };
            }).WithName("DeleteUserById");

            return routeBuilder;
        }
    }
}
