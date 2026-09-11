using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Yes.Shared.Settings;

namespace Yes.Application.Services;

public class TokenProviderService(IOptions<JwtSettings> jwtOptions)
{
    public string ProvideToken(Guid id)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, id.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.Key));

        var credetials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(claims: claims, expires: DateTime.UtcNow.AddMinutes(jwtOptions.Value.ExpiresInMinutes), signingCredentials: credetials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
