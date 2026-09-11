using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Requests;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints;

public static class RegisterEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapRegisterEndpoint()
        {
            routeBuilder.MapPost("register", async (IAuthenticationService authenticationService, RegisterRequest request) =>
            {
                var result = await authenticationService.RegisterAsync(request);

                return result switch
                {
                    RegisterResponse response => Results.CreatedAtRoute("GetUserById", new { id = response.Id }, response),
                    ValidationError validationError => Results.BadRequest(validationError),
                    EntityAlreadyExistsError entityAlreadyExistsError => Results.BadRequest(entityAlreadyExistsError)
                };
            }).WithName("Register");

            return routeBuilder;
        }
    }
}
