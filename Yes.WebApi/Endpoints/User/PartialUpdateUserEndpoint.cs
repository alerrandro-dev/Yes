using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Requests.User;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.User;

public static class PartialUpdateUserEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapPartialUpdateUserEndpoint()
        {
            routeBuilder.MapPatch("", async (IUserService service, UpdateUserRequest request) =>
            {
                var result = await service.PartialUpdateAsync(request);

                return result switch
                {
                    UserResponse response => Results.Ok(response),
                    ValidationError validationError => Results.BadRequest(validationError),
                    EntityNotFoundError entityNotFoundError => Results.NotFound(entityNotFoundError),
                    EntityAlreadyExistsError entityAlreadyExistsError => Results.BadRequest(entityAlreadyExistsError)
                };
            }).RequireAuthorization()
                .WithName("PartialUpdateUser");

            return routeBuilder;
        }
    }
}
