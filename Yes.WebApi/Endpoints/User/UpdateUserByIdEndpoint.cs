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
        public IEndpointRouteBuilder MapUpdateUserByIdEndpoint()
        {
            routeBuilder.MapPut("{id:guid}", async (IUserService service, Guid id, UpdateUserRequest request) =>
            {
                var result = await service.UpdateByIdAsync(id, request);

                return result switch
                {
                    UserResponse response => Results.Ok(response),
                    ValidationError validationError => Results.BadRequest(validationError),
                    EntityNotFoundError entityNotFound => Results.NotFound(entityNotFound),
                    EntityAlreadyExistsError entityAlreadyExists => Results.BadRequest(entityAlreadyExists)
                };
            }).WithName("UpdateUserById");

            return routeBuilder;
        }
    }
}
