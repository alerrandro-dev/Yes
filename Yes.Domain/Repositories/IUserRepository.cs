using Yes.Domain.Entities;

namespace Yes.Domain.Repositories;

public interface IUserRepository
{
    Task AddAsync(UserEntity entity);
    Task<UserEntity?> GetByIdAsync(Guid id);
    Task<UserEntity?> GetByEmailAsync(string email);
    Task<bool> DeleteByIdAsync(Guid id);
    Task<bool> ExistsUserWithIdAsync(Guid id);
    Task<bool> ExistsWithEmailAsync(string email);
    Task SaveChangesAsync();
}
