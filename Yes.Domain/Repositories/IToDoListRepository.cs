using Yes.Domain.Entities;

namespace Yes.Domain.Repositories;

public interface IToDoListRepository
{
    Task AddAsync(ToDoListEntity entity);
    Task<ToDoListEntity?> GetByIdAsync(Guid id);
    Task DeleteAsync(ToDoListEntity entity);
    Task<bool> ExistsWithIdAsync(Guid id);
    Task<bool> ExistsWithNameFromUserWithIdAsync(string name, Guid userId);
    Task SaveChangesAsync();
}
