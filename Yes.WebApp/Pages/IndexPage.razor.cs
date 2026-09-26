using Microsoft.AspNetCore.Components;

namespace Yes.WebApp.Pages;

public partial class IndexPage(NavigationManager navigationManager)
{
    protected override void OnInitialized()
    {
        navigationManager.NavigateTo("/login");
    }
}
