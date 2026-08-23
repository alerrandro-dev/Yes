using Yes.Shared.Requests.User;
using Yes.Shared.Results.User;

namespace Yes.Shared.Services;

public interface IUserService
{
    Task<AddUserResult> AddAsync(AddUserRequest request);
    Task<GetUserResult> GetByIdAsync(Guid id);
    Task<UpdateUserResult> UpdateByIdAsync(Guid id, UpdateUserRequest request);
    Task<DeleteUserResult> DeleteByIdAsync(Guid id);
}
