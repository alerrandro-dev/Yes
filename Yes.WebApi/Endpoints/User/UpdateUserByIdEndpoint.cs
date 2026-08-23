using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Requests.User;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.User;

public static class UpdateUserByIdEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder UseUpdateUserByIdEndpoint()
        {
            routeBuilder.MapPut("{id:guid}", UpdateByIdAsync);

            return routeBuilder;
        }
    }
    private static async Task<IResult> UpdateByIdAsync(IUserService service, Guid id, UpdateUserRequest request)
    {
        var result = await service.UpdateByIdAsync(id, request);

        return result switch
        {
            UserResponse response => Results.Ok(response),
            ValidationErrors validationErrors => Results.BadRequest(validationErrors),
            EntityNotFound entityNotFound => Results.NotFound(entityNotFound),
            EntityAlreadyExists entityAlreadyExists => Results.BadRequest(entityAlreadyExists)
        };
    }
}
