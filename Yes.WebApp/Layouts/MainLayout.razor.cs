using Mapster;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Yes.Shared.Contexts;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApp.Layouts;

public partial class MainLayout(IUserContext userContext, IUserService userService, NavigationManager navigationManager, ISnackbar snackbar)
{
    private bool _drawerIsOpened;

    private bool _isLoading = true;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var result = await userService.GetAsync();
            switch (result)
            {
                case UserResponse userResponse:
                    userResponse.Adapt(userContext);
                    userContext.IsAuthenticated = true;
                    break;
                case EntityNotFoundError entityNotFoundError:
                    snackbar.Add(entityNotFoundError.Message, Severity.Error, options => options.RequireInteraction = true);
                    navigationManager.NavigateTo("/register");
                    break;
            }
        } 
        catch (UnauthorizedAccessException)
        {
            userContext.IsAuthenticated = false;
            snackbar.Add("You didn't do login", Severity.Error, options => options.RequireInteraction = true);
            navigationManager.NavigateTo("/login");
        }
        finally
        {
            _isLoading = false;
        }
    }
    
    private void ChangeDrawerOpeningState() => _drawerIsOpened = !_drawerIsOpened;
}