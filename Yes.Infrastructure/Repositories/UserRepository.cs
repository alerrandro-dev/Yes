using Microsoft.EntityFrameworkCore;
using Yes.Domain.Entities;
using Yes.Domain.Repositories;

namespace Yes.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task AddAsync(UserEntity entity)
    {
        await context.Users.AddAsync(entity);
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var afectedRows = await context.Users
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync();

        return afectedRows > 0;
    }

    public async Task<bool> ExistsUserWithIdAsync(Guid id)
    {
        return await context.Users
            .AnyAsync(e => e.Id == id);
    }

    public async Task<bool> ExistsWithEmailAsync(string email)
    {
        return await context.Users
            .AnyAsync(e => e.Email == email);
    }

    public async Task<UserEntity?> GetByIdAsync(Guid id)
    {
        return await context.Users
            .Include(e => e.ToDoLists)
                .ThenInclude(e => e.Tasks)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
