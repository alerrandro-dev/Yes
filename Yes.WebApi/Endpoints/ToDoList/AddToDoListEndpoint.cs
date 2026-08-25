using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Requests.ToDoList;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApi.Endpoints.ToDoList;

public static class AddToDoListEndpoint
{
    extension(IEndpointRouteBuilder routeBuilder)
    {
        public IEndpointRouteBuilder MapAddToDoListEndpoint()
        {
            routeBuilder.MapPost("", AddAsync)
                .WithName("AddToDoList");

            return routeBuilder;
        }
    }

    private static async Task<IResult> AddAsync(IToDoListService service, AddToDoListRequest request)
    {
        var result = await service.AddAsync(request);

        return result switch
        {
            ToDoListResponse response => Results.CreatedAtRoute("GetToDoListById", new { id = response.Id }, response),
            ValidationError validationErrors => Results.BadRequest(validationErrors),
            EntityFromOwnerEntityAlreadyExistsError entityFromOwnerEntityAlreadyExists => Results.BadRequest(entityFromOwnerEntityAlreadyExists)
        };
    }
}
