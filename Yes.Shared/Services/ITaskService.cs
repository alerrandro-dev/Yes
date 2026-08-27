using Yes.Shared.Requests.Task;
using Yes.Shared.Results.Task;

namespace Yes.Shared.Services;

public interface ITaskService
{
    Task<AddTaskResult> AddAsync(AddTaskRequest request);
    Task<GetTaskResult> GetByIdAsync(Guid id);
    Task<UpdateTaskResult> UpdateByIdAsync(Guid id, UpdateTaskRequest request);
    Task<DeleteTaskResult> DeleteByIdAsync(Guid id);
}