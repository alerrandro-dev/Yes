using Yes.Shared.Responses;

namespace Yes.Shared.Contexts;

public interface IUserContext
{
    Guid Id { get; set; }
    string Username { get; set; }
    string Email { get; set; }
    bool IsAuthenticated { get; set; }
}
