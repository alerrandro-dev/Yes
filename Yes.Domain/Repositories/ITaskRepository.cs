using Yes.Domain.Entities;

namespace Yes.Domain.Repositories;

public interface ITaskRepository
{
    Task AddAsync(TaskEntity entity);
    Task<TaskEntity?> GetByIdAsync(Guid id);
    Task DeleteAsync(TaskEntity entity);
    Task<bool> ExistsWithNameFromToDoListWithIdAsync(string name, Guid toDoListId);
    Task SaveChangesAsync();
}
