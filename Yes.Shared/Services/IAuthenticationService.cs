using Yes.Shared.Requests;
using Yes.Shared.Results;

namespace Yes.Shared.Services;

public interface IAuthenticationService
{
    Task<ResgisterResult> RegisterAsync(RegisterRequest request);
    Task<LoginResult> LoginAsync(LoginRequest request);
}
