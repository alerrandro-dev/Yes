using Microsoft.EntityFrameworkCore;
using Yes.Infrastructure;
using Yes.WebApi.DependencyInjections.ToDoList;
using Yes.WebApi.DependencyInjections.User;
using Yes.WebApi.Endpoints.ToDoList;
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

builder.Services.AddToDoListRepositoryDependencyInjection()
    .AddToDoListServiceDependencyInjection()
    .AddAddToDoListValidatorDependencyInjection()
    .AddUpdateToDoListValidatorDependencyInjection();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

var userGroup = app.MapGroup("/api/users");
userGroup.MapAddUserEndpoint()
    .MapGetUserByIdEndpoint()
    .MapUpdateUserByIdEndpoint()
    .MapDeleteUserByIdEndpoint();

var toDoListGroup = app.MapGroup("/api/todolists");
toDoListGroup.MapAddToDoListEndpoint()
    .MapGetToDoListByIdEndpoint()
    .MapUpdateToDoListByIdEndpoint()
    .MapDeleteToDoListByIdEndpoint();

await app.RunAsync();