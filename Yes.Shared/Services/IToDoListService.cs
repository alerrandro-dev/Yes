using Yes.Shared.Requests.ToDoList;
using Yes.Shared.Results.ToDoList;

namespace Yes.Shared.Services;

public interface IToDoListService
{
    Task<AddToDoListResult> AddAsync(AddToDoListRequest request);
    Task<GetToDoListResult> GetByIdAsync(Guid id);
    Task<UpdateToDoListResult> FullUpdateByIdAsync(Guid id, UpdateToDoListRequest request);
    Task<DeleteToDoListResult> DeleteByIdAsync(Guid id);
}
