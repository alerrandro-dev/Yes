using System.Text.Json;
using Yes.Shared.Requests;
using Yes.Shared.Results;
using Yes.Shared.Services;

namespace Yes.WebApp.Services;

public class AuthenticationService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions) : IAuthenticationService
{
    public async Task<LoginResult> LoginAsync(LoginRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<ResgisterResult> RegisterAsync(RegisterRequest request)
    {
        var httpResponse = await httpClient.PostAsJsonAsync("authentication/register", request);

        var result = await httpResponse.Content.ReadFromJsonAsync<ResgisterResult>(jsonSerializerOptions);
        return result;
    }
}
