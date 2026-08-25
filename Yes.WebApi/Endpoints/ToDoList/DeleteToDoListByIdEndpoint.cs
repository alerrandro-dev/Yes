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
            routeBuilder.MapDelete("{id:guid}", DeleteByIdAsync)
                .WithName("DeleteToDoListById");

            return routeBuilder;
        }
    }
    private static async Task<IResult> DeleteByIdAsync(IToDoListService service, Guid id)
    {
        var result = await service.DeleteByIdAsync(id);

        return result switch
        {
            Success success => Results.NoContent(),
            EntityNotFoundError entityNotFound => Results.NotFound(entityNotFound)
        };
    }
}
