using Yes.Shared.Requests.User;
using Yes.Shared.Results.User;

namespace Yes.Shared.Services;

public interface IUserService
{
    Task<AddUserResult> AddAsync(AddUserRequest request);
    Task<GetUserResult> GetAsync();
    Task<UpdateUserResult> FullUpdateAsync(UpdateUserRequest request);
    Task<UpdateUserResult> PartialUpdateAsync(UpdateUserRequest request);
    Task<DeleteUserResult> DeleteAsync();
}
