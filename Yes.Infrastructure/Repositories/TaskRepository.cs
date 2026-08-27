using Microsoft.EntityFrameworkCore;
using Yes.Domain.Entities;
using Yes.Domain.Repositories;

namespace Yes.Infrastructure.Repositories;

public class TaskRepository(AppDbContext context) : ITaskRepository
{
    public async Task AddAsync(TaskEntity entity)
    {
        await context.Tasks.AddAsync(entity);
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        int afectedRows = await context.Tasks
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync();

        return afectedRows > 0;
    }

    public async Task<bool> ExistsWithNameFromToDoListWithIdAsync(string name, Guid toDoListId)
    {
        return await context.Tasks
            .AnyAsync(e => e.Name == name && e.ToDoListId == toDoListId);
    }

    public async Task<TaskEntity?> GetByIdAsync(Guid id)
    {
        return await context.Tasks
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
