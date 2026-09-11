using System.Security.Claims;
using Yes.Shared.Contexts;

namespace Yes.WebApi.Contexts;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public Guid Id { get; } = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
}
