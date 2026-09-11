using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Requests.Task;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.Task;

public static class AddTaskEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapAddTaskEndpoint()
        {
            routeBuilder.MapPost("", async (ITaskService service, AddTaskRequest request) =>
            {
                var result = await service.AddAsync(request);

                return result switch
                {
                    TaskResponse response => Results.CreatedAtRoute("GetTaskById", new { id = response.Id }, response),
                    ValidationError validationError => Results.BadRequest(validationError),
                    EntityNotFoundError entityNotFoundError => Results.NotFound(entityNotFoundError),
                    EntityFromOwnerEntityAlreadyExistsError entityFromOwnerEntityAlreadyExistsError => Results.BadRequest(entityFromOwnerEntityAlreadyExistsError)
                };
            }).RequireAuthorization()
                .WithName("AddTask");

            return routeBuilder;
        }
    }
}
