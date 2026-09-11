using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Requests;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints;

public static class LoginEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapLoginEndpoint()
        {
            routeBuilder.MapPost("login", async (IAuthenticationService authenticationService, LoginRequest request) =>
            {
                var result = await authenticationService.LoginAsync(request);

                return result switch
                {
                    LoginResponse response => Results.Ok(response),
                    ValidationError validationError => Results.BadRequest(validationError),
                    EntityNotFoundError entityNotFoundError => Results.NotFound(entityNotFoundError),
                    IncorrectPasswordError incorrectPasswordError => Results.BadRequest(incorrectPasswordError)
                };
            }).WithName("Login");

            return routeBuilder;
        }
    }
}
