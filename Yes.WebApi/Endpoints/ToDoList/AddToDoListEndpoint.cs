using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Requests.ToDoList;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.ToDoList;

public static class AddToDoListEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapAddToDoListEndpoint()
        {
            routeBuilder.MapPost("", async (IToDoListService service, AddToDoListRequest request) =>
            {
                var result = await service.AddAsync(request);

                return result switch
                {
                    ToDoListResponse response => Results.CreatedAtRoute("GetToDoListById", new { id = response.Id }, response),
                    ValidationError validationErrors => Results.BadRequest(validationErrors),
                    EntityNotFoundError entityNotFoundError => Results.NotFound(entityNotFoundError),
                    EntityFromOwnerEntityAlreadyExistsError entityFromOwnerEntityAlreadyExistsError => Results.BadRequest(entityFromOwnerEntityAlreadyExistsError)
                };
            }).RequireAuthorization()
                .WithName("AddToDoList");

            return routeBuilder;
        }
    }
}
