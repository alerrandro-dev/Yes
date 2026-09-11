using Yes.Shared.Errors.Entity;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.Task;

public static class GetTaskByIdEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapGetTaskByIdEndpoint()
        {
            routeBuilder.MapGet("{id:guid}", async (ITaskService service, Guid id) =>
            {
                var result = await service.GetByIdAsync(id);

                return result switch
                {
                    TaskResponse response => Results.Ok(response),
                    EntityNotFoundError entityNotFoundError => Results.NotFound(entityNotFoundError)
                };
            }).RequireAuthorization()
                .WithName("GetTaskById");

            return routeBuilder;
        }
    }
}
