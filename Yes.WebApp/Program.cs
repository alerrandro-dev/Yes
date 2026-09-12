using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Yes.WebApp;
using Yes.WebApp.DependencyInjections;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddAuthenticationServiceDependencyInjection();

builder.Services.AddJsonSerializerOptionsDependencyInjection();

var httpClient = new HttpClient();
var uri = new Uri("http://localhost:5200/api/");
httpClient.BaseAddress = uri;

builder.Services.AddSingleton(httpClient);

await builder.Build().RunAsync();
