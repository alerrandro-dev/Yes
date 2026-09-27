using FluentValidation;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests;
using Yes.Shared.Responses;
using Yes.Shared.Services;
using Yes.WebApp.Extensions;

namespace Yes.WebApp.Pages;

public partial class RegisterPage(IAuthenticationService authenticationService, NavigationManager navigationManager, ISnackbar snackbar,
    IValidator<RegisterRequest> validator)
{
    private RegisterRequest _request = new();

    private async Task EnterAsync()
    {
        snackbar.Clear();

        var isValidBeforeSedingRequest = await _request.IsValidBeforeSedingRequestAsync(validator, snackbar);
        if (!isValidBeforeSedingRequest) return;

        var result = await authenticationService.RegisterAsync(_request);
        switch (result)
        {
            case RegisterResponse response:
                snackbar.Add($"You are registered, {response.Username}", MudBlazor.Severity.Success);
                navigationManager.NavigateTo("/login");
                break;
            case ValidationError validationError:
                foreach (var error in validationError.Errors) snackbar.Add(error, MudBlazor.Severity.Error, options => options.RequireInteraction = true);
                break;
            case EntityAlreadyExistsError entityAlreadyExistsError:
                snackbar.Add(entityAlreadyExistsError.Message, MudBlazor.Severity.Error, options => options.RequireInteraction = true);
                break;
        }
    }
}
