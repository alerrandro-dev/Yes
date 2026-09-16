using Microsoft.AspNetCore.Http;

namespace Yes.Application.Services;

public class CookieService(IHttpContextAccessor httpContextAccessor)
{
    public async Task AddTokenCookieAsync(string token)
    {
        var options = new CookieOptions
        {
            HttpOnly = true,
            Path = "/",
            SameSite = SameSiteMode.Lax,
            MaxAge = TimeSpan.FromMinutes(30)
        };
        httpContextAccessor.HttpContext.Response.Cookies.Append("authentication", token, options);
    }
}
