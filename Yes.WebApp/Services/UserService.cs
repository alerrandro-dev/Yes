using System.Text.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Yes.Shared.Requests.User;
using Yes.Shared.Results.User;
using Yes.Shared.Services;

namespace Yes.WebApp.Services;

public class UserService(IHttpClientFactory httpClientFactory, JsonSerializerOptions jsonSerializerOptions) : IUserService
{
    private HttpClient _httpClient = httpClientFactory.CreateClient("Api");

    public async Task<AddUserResult> AddAsync(AddUserRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<GetUserResult> GetAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<GetUserResult>("users", jsonSerializerOptions);
        return result;
    }

    public async Task<UpdateUserResult> FullUpdateAsync(UpdateUserRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<UpdateUserResult> PartialUpdateAsync(UpdateUserRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<DeleteUserResult> DeleteAsync()
    {
        throw new NotImplementedException();
    }
}