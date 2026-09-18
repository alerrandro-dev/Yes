using System.Text.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Yes.Shared.Requests.User;
using Yes.Shared.Results.User;
using Yes.Shared.Services;

namespace Yes.WebApp.Services;

public class UserService(HttpClient httpClient, JsonSerializerOptions jsonSerializerOptions) : IUserService
{
    public async Task<AddUserResult> AddAsync(AddUserRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<GetUserResult> GetAsync()
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Get, "users");
        httpRequest.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
        
        var httpResponse = await httpClient.SendAsync(httpRequest);
        
        var result = await httpResponse.Content.ReadFromJsonAsync<GetUserResult>(jsonSerializerOptions);
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