using Microsoft.EntityFrameworkCore;
using Yes.Domain.Entities;
using Yes.Domain.Repositories;

namespace Yes.Infrastructure.Repositories;

public class ToDoListRepository(AppDbContext context) : IToDoListRepository
{
    public async Task AddAsync(ToDoListEntity entity)
    {
        await context.ToDoLists.AddAsync(entity);
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var afectedRows = await context.ToDoLists
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync();

        return afectedRows > 0;
    }

    public async Task<bool> ExistsWithIdAsync(Guid id)
    {
        return await context.ToDoLists
            .AnyAsync(e => e.Id == id);
    }

    public async Task<bool> ExistsWithNameFromUserWithIdAsync(string name, Guid userId)
    {
        return await context.ToDoLists
            .AnyAsync(e => e.Name == name && e.UserId == userId);
    }

    public async Task<ToDoListEntity?> GetByIdAsync(Guid id)
    {
        return await context.ToDoLists
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
