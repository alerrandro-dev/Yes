using Yes.Application.Services;
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
            routeBuilder.MapPost("login", async (IAuthenticationService authenticationService, CookieService cookieService, LoginRequest request) =>
            {
                var result = await authenticationService.LoginAsync(request);

                return result switch
                {
                    LoginResponse response => await routeBuilder.HandleLoginAsync(cookieService, response),
                    ValidationError validationError => Results.BadRequest(validationError),
                    EntityNotFoundError entityNotFoundError => Results.NotFound(entityNotFoundError),
                    IncorrectPasswordError incorrectPasswordError => Results.BadRequest(incorrectPasswordError)
                };
            }).WithName("Login");

            return routeBuilder;
        }

        private async Task<IResult> HandleLoginAsync(CookieService cookieService, LoginResponse response)
        {
            await cookieService.AddTokenCookieAsync(response.Token);

            return Results.Ok(response);
        }
    }
}
