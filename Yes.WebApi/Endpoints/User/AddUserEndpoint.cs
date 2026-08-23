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
        public IEndpointRouteBuilder UseAddUserEndpoint()
        {
            routeBuilder.MapPost("", AddAsync);

            return routeBuilder;
        }
    }

    private static async Task<IResult> AddAsync(IUserService service, AddUserRequest request)
    {
        var result = await service.AddAsync(request);

        return result switch
        {
            UserResponse response => Results.CreatedAtRoute("GetUserById", new { id = response.Id }, response),
            ValidationErrors validationErrors => Results.BadRequest(validationErrors),
            EntityAlreadyExists entityAlreadyExists => Results.BadRequest(entityAlreadyExists)
        };
    }
}
