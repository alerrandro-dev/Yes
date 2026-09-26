using Yes.Shared.Contexts;
using Yes.Shared.Responses;

namespace Yes.WebApp.Contexts;

public class UserContext : IUserContext
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool IsAuthenticated { get; set; } = false;
}
