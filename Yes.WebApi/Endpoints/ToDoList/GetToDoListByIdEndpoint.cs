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
            routeBuilder.MapGet("{id:guid}", async (IToDoListService service, Guid id) =>
            {
                var result = await service.GetByIdAsync(id);

                return result switch
                {
                    ToDoListResponse response => Results.Ok(response),
                    EntityNotFoundError entityNotFoundError => Results.NotFound(entityNotFoundError)
                };
            }).RequireAuthorization()
                .WithName("GetToDoListById");

            return routeBuilder;
        }
    }
}
