using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Yes.WebApp;
using Yes.WebApp.DependencyInjections;
using Yes.WebApp.DependencyInjections.User;
using Yes.WebApp.Handlers;

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
    .AddRegisterValidatorDependencyInjection()
    .AddLoginValidatorDependencyInjection();

builder.Services.AddJsonSerializerOptionsDependencyInjection();

builder.Services.AddUserServiceDependencyInjection()
    .AddUserContextDependencyInjection();

builder.Services.AddBrowserCredentialsHandlerDependencyInjection();

builder.Services.AddHttpClient("Api", client =>
{
    var uri = new Uri("http://localhost:5200/api/");
    client.BaseAddress = uri;
}).AddHttpMessageHandler<BrowserCredentialsHandler>();

var app = builder.Build();
await app.RunAsync();