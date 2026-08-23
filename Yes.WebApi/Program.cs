using Microsoft.EntityFrameworkCore;
using Yes.Infrastructure.Persistence;
using Yes.WebApi.DependencyInjections.User;
using Yes.WebApi.Endpoints.User;
using Yes.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddUserRepositoryDependencyInjection()
    .AddUserServiceDependencyInjection()
    .AddAddUserValidatorDependencyInjection()
    .AddUpdateUserValidatorDependencyInjection();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

var userGroup = app.MapGroup("/api/users");

userGroup.UseAddUserEndpoint()
    .UseGetUserByIdEndpoint()
    .UseUpdateUserByIdEndpoint()
    .UseDeleteUserByIdEndpoint();

await app.RunAsync();