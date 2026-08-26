using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Requests.ToDoList;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.ToDoList;

public static class UpdateToDoListByIdEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapUpdateToDoListByIdEndpoint()
        {
            routeBuilder.MapPut("{id:guid}", async (IToDoListService service, Guid id, UpdateToDoListRequest request) =>
            {
                var result = await service.UpdateByIdAsync(id, request);

                return result switch
                {
                    ToDoListResponse response => Results.Ok(response),
                    ValidationError validationError => Results.BadRequest(validationError),
                    EntityNotFoundError entityNotFound => Results.NotFound(entityNotFound),
                    EntityFromOwnerEntityAlreadyExistsError entityFromOwnerEntityAlreadyExists => Results.BadRequest(entityFromOwnerEntityAlreadyExists)
                };
            }).WithName("UpdateToDoListById");

            return routeBuilder;
        }
    }
}
