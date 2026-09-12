using MudBlazor;
using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Requests;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApp.Pages;

public partial class Register(IAuthenticationService authenticationService, IDialogService dialogService)
{
    private string _username = string.Empty;
    private string _email = string.Empty;
    private string _password = string.Empty;

    private async Task SubmitAsync()
    {
        var request = new RegisterRequest(_username, _email, _password);
        var result = await authenticationService.RegisterAsync(request);

        switch (result)
        {
            case RegisterResponse response:
                await dialogService.ShowMessageBoxAsync($"Welcome, {response.Username}", $"Your datas: {response}");
                break;
            case ValidationError validationError:
                await dialogService.ShowMessageBoxAsync($"You made a mistake", validationError.Message);
                break;
            case EntityAlreadyExistsError entityAlreadyExistsError:
                await dialogService.ShowMessageBoxAsync($"You made a mistake", entityAlreadyExistsError.Message);
                break;
        }
    }
}
