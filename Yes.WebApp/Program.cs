using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Yes.WebApp;
using Yes.WebApp.DependencyInjections;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices(configuration =>
{
    configuration.SnackbarConfiguration.PreventDuplicates = true;
    configuration.SnackbarConfiguration.MaxDisplayedSnackbars = 6;
    configuration.SnackbarConfiguration.ShowTransitionDuration = 500;
    configuration.SnackbarConfiguration.HideTransitionDuration = 500;
});

builder.Services.AddAuthenticationServiceDependencyInjection()
    .AddRegisterValidatorDependencyInjection();

builder.Services.AddJsonSerializerOptionsDependencyInjection();

var httpClient = new HttpClient();
var uri = new Uri("http://localhost:5200/api/");
httpClient.BaseAddress = uri;

builder.Services.AddSingleton(httpClient);

await builder.Build().RunAsync();
