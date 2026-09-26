using System.Security.Claims;
using Yes.Shared.Contexts;
using Yes.Shared.Responses;

namespace Yes.WebApi.Contexts;

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public Guid Id { get; set; } = Guid.Parse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    public string Username { get; set; } = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
    public string Email { get; set; } = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
    public bool IsAuthenticated { get; set; } = httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
}
