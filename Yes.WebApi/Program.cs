using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Scalar.AspNetCore;
using System.Text;
using Yes.Infrastructure;
using Yes.Shared.Settings;
using Yes.WebApi.DependencyInjections;
using Yes.WebApi.DependencyInjections.Task;
using Yes.WebApi.DependencyInjections.ToDoList;
using Yes.WebApi.DependencyInjections.User;
using Yes.WebApi.Endpoints;
using Yes.WebApi.Endpoints.Task;
using Yes.WebApi.Endpoints.ToDoList;
using Yes.WebApi.Endpoints.User;
using Yes.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtOptions = builder.Services.BuildServiceProvider().GetRequiredService<IOptions<JwtSettings>>().Value;

        options.TokenValidationParameters = new()
        {
            ValidateLifetime = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer(async (document, context, cancellationToken) =>
    {
        document.Components ??= new();
        document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();

        document.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme()
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
        };
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("Blazor", policy =>
    {
        policy.WithOrigins("http://localhost:5062");
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddUserRepositoryDependencyInjection()
    .AddUserServiceDependencyInjection()
    .AddAddUserValidatorDependencyInjection()
    .AddFullUpdateUserValidatorDependencyInjection()
    .AddPartialUpdateUserValidatorDependencyInjection()
    .AddUserContextDependencyInjection()
    .AddUpdateUserRequestToUserEntityTypeAdapterConfigDependencyInjection();

builder.Services.AddToDoListRepositoryDependencyInjection()
    .AddToDoListServiceDependencyInjection()
    .AddAddToDoListValidatorDependencyInjection()
    .AddFullUpdateToDoListValidatorDependencyInjection();

builder.Services.AddTaskRepositoryDependencyInjection()
    .AddTaskServiceDependencyInjection()
    .AddAddTaskValidatorDependencyInjection()
    .AddFullUpdateTaskValidatorDependencyInjection()
    .AddPartialUpdateTaskValidatorDependencyInjection()
    .AddUpdateTaskRequestToTaskEntityTypeAdapterConfigDependencyInjection();

builder.Services.AddAuthenticationServiceDependencyInjection()
    .AddRegisterValidatorDependencyInjection()
    .AddLoginValidatorDependencyInjection();

builder.Services.AddTokenProviderServiceDependencyInjection();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseCors("Blazor");

app.UseAuthentication();
app.UseAuthorization();

app.MapOpenApi();
app.MapScalarApiReference();


app.MapGroup("api/users")
    .MapAddUserEndpoint()
    .MapGetUserEndpoint()
    .MapFullUpdateUserEndpoint()
    .MapPartialUpdateUserEndpoint()
    .MapDeleteUserEndpoint();

app.MapGroup("api/todo-lists")
    .MapAddToDoListEndpoint()
    .MapGetToDoListByIdEndpoint()
    .MapFullUpdateToDoListByIdEndpoint()
    .MapDeleteToDoListByIdEndpoint();

app.MapGroup("api/tasks")
    .MapAddTaskEndpoint()
    .MapGetTaskByIdEndpoint()
    .MapFullUpdateTaskByIdEndpoint()
    .MapPartialUpdateTaskByIdEndpoint()
    .MapDeleteTaskByIdEndpoint();

app.MapGroup("api/authentication")
    .MapRegisterEndpoint()
    .MapLoginEndpoint();

await app.RunAsync();