using Microsoft.EntityFrameworkCore;
using Yes.Infrastructure;
using Yes.WebApi.DependencyInjections.Task;
using Yes.WebApi.DependencyInjections.ToDoList;
using Yes.WebApi.DependencyInjections.User;
using Yes.WebApi.Endpoints.Task;
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

builder.Services.AddTaskRepositoryDependencyInjection()
    .AddTaskServiceDependencyInjection()
    .AddAddTaskValidatorDependencyInjection()
    .AddUpdateTaskValidatorDependencyInjection();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapGroup("api/users").MapAddUserEndpoint()
    .MapGetUserByIdEndpoint()
    .MapUpdateUserByIdEndpoint()
    .MapDeleteUserByIdEndpoint();

app.MapGroup("api/todo-lists")
    .MapAddToDoListEndpoint()
    .MapGetToDoListByIdEndpoint()
    .MapUpdateToDoListByIdEndpoint()
    .MapDeleteToDoListByIdEndpoint();

app.MapGroup("api/tasks")
    .MapAddTaskEndpoint()
    .MapGetTaskByIdEndpoint()
    .MapUpdateTaskByIdEndpoint()
    .MapDeleteTaskByIdEndpoint();

await app.RunAsync();