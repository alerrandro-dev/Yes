using Yes.Shared.Errors.Entity;
using Yes.Shared.Results;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.Task;

public static class DeleteTaskByIdEnpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapDeleteTaskByIdEndpoint()
        {
            routeBuilder.MapDelete("{id:guid}", async (ITaskService service, Guid id) =>
            {
                var result = await service.DeleteByIdAsync(id);

                return result switch
                {
                    Success success => Results.NoContent(),
                    EntityNotFoundError entityNotFoundError => Results.NotFound(entityNotFoundError)
                };
            }).RequireAuthorization()
                .WithName("DeleteTaskById");

            return routeBuilder;
        }
    }
}
