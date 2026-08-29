using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Requests.Task;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.Task;

public static class UpdateTaskByIdEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapUpdateTaskByIdEndpoint()
        {
            routeBuilder.MapPut("{id:guid}", async (ITaskService service, Guid id, UpdateTaskRequest request) =>
            {
                var result = await service.UpdateByIdAsync(id, request);

                return result switch
                {
                    TaskResponse response => Results.Ok(response),
                    ValidationError validationError => Results.BadRequest(validationError),
                    EntityNotFoundError entityNotFoundError => Results.NotFound(entityNotFoundError),
                    EntityFromOwnerEntityAlreadyExistsError entityFromOwnerEntityAlreadyExistsError => Results.BadRequest(entityFromOwnerEntityAlreadyExistsError)
                };
            }).WithName("UpdateTaskById");

            return routeBuilder;
        }
    }
}
