using Yes.Shared.Errors.Entity;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.ToDoList;

public static class GetToDoListByIdEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapGetToDoListByIdEndpoint()
        {
            routeBuilder.MapGet("{id:guid}", GetByIdAsync)
                .WithName("GetToDoListById");

            return routeBuilder;
        }
    }

    private static async Task<IResult> GetByIdAsync(IToDoListService service, Guid id)
    {
        var result = await service.GetByIdAsync(id);

        return result switch
        {
            ToDoListResponse response => Results.Ok(response),
            EntityNotFoundError entityNotFound => Results.NotFound(entityNotFound)
        };
    }
}
