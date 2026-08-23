using Yes.Shared.Errors.Entity;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.User;

public static class GetUserByIdEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder UseGetUserByIdEndpoint()
        {
            routeBuilder.MapGet("{id:guid}", GetByIdAsync)
                .WithName("GetUserById");

            return routeBuilder;
        }
    }

    private static async Task<IResult> GetByIdAsync(IUserService service, Guid id)
    {
        var result = await service.GetByIdAsync(id);

        return result switch
        {
            UserResponse response => Results.Ok(response),
            EntityNotFound entityNotFound => Results.NotFound(entityNotFound)
        };
    }
}
