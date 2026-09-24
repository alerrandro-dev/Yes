using Microsoft.AspNetCore.Components;
using MudBlazor;
using Yes.Shared.Contexts;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApp.Pages;

public partial class HomePage(IUserContext userContext, NavigationManager navigationManager, ISnackbar snackbar)
{
    private UserResponse? _userResponse;

    protected override void OnInitialized()
    {
        if (userContext.Response is null)
        {
            snackbar.Add("You didn't login", Severity.Error, options => options.RequireInteraction = true);

            navigationManager.NavigateTo("/login");
            return;
        }

        _userResponse = userContext.Response;
    }
}