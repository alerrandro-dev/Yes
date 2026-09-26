using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System.Text.Json;
using Yes.Shared.Requests;
using Yes.Shared.Results;
using Yes.Shared.Services;

namespace Yes.WebApp.Services;

public class AuthenticationService(IHttpClientFactory httpClientFactory, JsonSerializerOptions jsonSerializerOptions) : IAuthenticationService
{
    private HttpClient _httpClient = httpClientFactory.CreateClient("Api");

    public async Task<LoginResult> LoginAsync(LoginRequest request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("authentication/login", request);
        
        var result = await httpResponse.Content.ReadFromJsonAsync<LoginResult>(jsonSerializerOptions);
        return result;
    }

    public async Task<ResgisterResult> RegisterAsync(RegisterRequest request)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("authentication/register", request);

        var result = await httpResponse.Content.ReadFromJsonAsync<ResgisterResult>(jsonSerializerOptions);
        return result;
    }
}
