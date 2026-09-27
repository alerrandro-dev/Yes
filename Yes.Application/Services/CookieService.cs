using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Yes.Shared.Settings;

namespace Yes.Application.Services;

public class CookieService(IHttpContextAccessor httpContextAccessor, IOptions<JwtSettings> jwtOptions)
{
    public async Task AddTokenCookieAsync(string token)
    {
        var options = new CookieOptions
        {
            HttpOnly = true,
            Path = "/",
            SameSite = SameSiteMode.Lax,
            MaxAge = TimeSpan.FromMinutes(jwtOptions.Value.ExpiresInMinutes)
        };
        httpContextAccessor.HttpContext.Response.Cookies.Append("authentication", token, options);
    }
}
