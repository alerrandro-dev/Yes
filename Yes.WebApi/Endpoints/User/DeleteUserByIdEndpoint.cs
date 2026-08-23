using Yes.Shared.Errors.Entity;
using Yes.Shared.Results;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.User;

public static class DeleteUserByIdEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder UseDeleteUserByIdEndpoint()
        {
            routeBuilder.MapDelete("{id:guid}", DeleteByIdAsync);

            return routeBuilder;
        }
    }
    private static async Task<IResult> DeleteByIdAsync(IUserService service, Guid id)
    {
        var result = await service.DeleteByIdAsync(id);

        return result switch
        {
            Success success => Results.NoContent(),
            EntityNotFound entityNotFound => Results.NotFound(entityNotFound)
        };
    }
}
