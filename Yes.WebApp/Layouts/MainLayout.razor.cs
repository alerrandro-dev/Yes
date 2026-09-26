using Microsoft.AspNetCore.Components;
using MudBlazor;
using Yes.Shared.Contexts;
using Yes.Shared.Responses;

namespace Yes.WebApp.Layouts;

public partial class MainLayout(IUserContext userContext, NavigationManager navigationManager, ISnackbar snackbar)
{
    private bool _drawerIsOpened;

    protected override void OnInitialized()
    {
        if (!userContext.IsAuthenticated)
        {
            snackbar.Add("You didn't do login", Severity.Error, options => options.RequireInteraction = true);

            navigationManager.NavigateTo("/login");
        }
    }
    
    private void ChangeDrawerOpeningState() => _drawerIsOpened = !_drawerIsOpened;
}