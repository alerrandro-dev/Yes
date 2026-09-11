using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Requests.ToDoList;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.ToDoList;

public static class FullUpdateToDoListByIdEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapFullUpdateToDoListByIdEndpoint()
        {
            routeBuilder.MapPut("{id:guid}", async (IToDoListService service, Guid id, UpdateToDoListRequest request) =>
            {
                var result = await service.FullUpdateByIdAsync(id, request);

                return result switch
                {
                    ToDoListResponse response => Results.Ok(response),
                    ValidationError validationError => Results.BadRequest(validationError),
                    EntityNotFoundError entityNotFoundError => Results.NotFound(entityNotFoundError),
                    EntityFromOwnerEntityAlreadyExistsError entityFromOwnerEntityAlreadyExistsError => Results.BadRequest(entityFromOwnerEntityAlreadyExistsError)
                };
            }).RequireAuthorization()
                .WithName("UpdateToDoListById");

            return routeBuilder;
        }
    }
}
