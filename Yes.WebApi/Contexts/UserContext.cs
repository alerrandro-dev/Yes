using System.Security.Claims;
using Yes.Shared.Contexts;
using Yes.Shared.Responses;

namespace Yes.WebApi.Contexts;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public Guid Id { get; set; } = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    public UserResponse? Response { get; set; }
}
