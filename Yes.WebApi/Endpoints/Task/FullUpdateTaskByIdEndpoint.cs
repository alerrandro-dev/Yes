using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Requests.Task;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.Task;

public static class FullUpdateTaskByIdEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapFullUpdateTaskByIdEndpoint()
        {
            routeBuilder.MapPut("{id:guid}", async (ITaskService service, Guid id, UpdateTaskRequest request) =>
            {
                var result = await service.FullUpdateByIdAsync(id, request);

                return result switch
                {
                    TaskResponse response => Results.Ok(response),
                    ValidationError validationError => Results.BadRequest(validationError),
                    EntityNotFoundError entityNotFoundError => Results.NotFound(entityNotFoundError),
                    EntityFromOwnerEntityAlreadyExistsError entityFromOwnerEntityAlreadyExistsError => Results.BadRequest(entityFromOwnerEntityAlreadyExistsError)
                };
            }).RequireAuthorization()
                .WithName("FullUpdateTaskById");

            return routeBuilder;
        }
    }
}
