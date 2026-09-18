using MudBlazor;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApp.Pages;

public partial class HomePage(IUserService userService, ISnackbar snackbar)
{
    private UserResponse? _userResponse;

    protected override async Task OnInitializedAsync()
    {
        var result = await userService.GetAsync();

        switch (result)
        {
            case UserResponse userResponse:
                _userResponse = userResponse;
                break;
            case EntityNotFoundError entityNotFoundError:
                snackbar.Add(entityNotFoundError.Message, Severity.Error, options => options.RequireInteraction = true);
                break;
        }
    }
}