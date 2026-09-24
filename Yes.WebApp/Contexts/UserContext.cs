using Yes.Shared.Contexts;
using Yes.Shared.Responses;

namespace Yes.WebApp.Contexts;

public class UserContext : IUserContext
{
    public Guid Id { get; set; }
    public UserResponse? Response { get; set; }
}
