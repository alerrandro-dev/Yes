using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Requests.User;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.User;

public static class AddUserEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapAddUserEndpoint()
        {
            routeBuilder.MapPost("", async (IUserService service, AddUserRequest request) =>
            {
                var result = await service.AddAsync(request);

                return result switch
                {
                    UserResponse response => Results.CreatedAtRoute("GetUserById", new { id = response.Id }, response),
                    ValidationError validationError => Results.BadRequest(validationError),
                    EntityAlreadyExistsError entityAlreadyExistsError => Results.BadRequest(entityAlreadyExistsError)
                };
            }).WithName("AddUser");

            return routeBuilder;
        }
    }
}
