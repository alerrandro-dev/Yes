using Yes.Shared.Errors.Entity;
using Yes.Shared.Results;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.ToDoList;

public static class DeleteToDoListByIdEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapDeleteToDoListByIdEndpoint()
        {
            routeBuilder.MapDelete("{id:guid}", async (IToDoListService service, Guid id) =>
            {
                var result = await service.DeleteByIdAsync(id);

                return result switch
                {
                    Success success => Results.NoContent(),
                    EntityNotFoundError entityNotFound => Results.NotFound(entityNotFound)
                };
            }).WithName("DeleteToDoListById");

            return routeBuilder;
        }
    }
}
