using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Requests.Task;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.Task;

public static class PartialUpdateTaskByIdEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapPartialUpdateTaskByIdEndpoint()
        {
            routeBuilder.MapPatch("{id:guid}", async (ITaskService service, Guid id, UpdateTaskRequest request) =>
            {
                var result = await service.PartialUpdateByIdAsync(id, request);

                return result switch
                {
                    TaskResponse response => Results.Ok(response),
                    ValidationError validationError => Results.BadRequest(validationError),
                    EntityNotFoundError entityNotFoundError => Results.NotFound(entityNotFoundError),
                    EntityFromOwnerEntityAlreadyExistsError entityFromOwnerEntityAlreadyExistsError => Results.BadRequest(entityFromOwnerEntityAlreadyExistsError)
                };
            }).RequireAuthorization()
                .WithName("PartialUpdateTaskById");

            return routeBuilder;
        }
    }
}
