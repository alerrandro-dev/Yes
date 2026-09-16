using FluentValidation;
using MudBlazor;
using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApp.Pages;

public partial class LoginPage(IAuthenticationService authenticationService, ISnackbar snackbar, IValidator<LoginRequest> validator)
{
    private LoginRequest _request = new();

    private async Task EnterAsync()
    {
        snackbar.Clear();

        var validationResult = await validator.ValidateAsync(_request);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.ErrorsToStringArray();
            foreach (var error in errors) snackbar.Add(error, MudBlazor.Severity.Error, options => options.RequireInteraction = true);

            return;
        }

        var result = await authenticationService.LoginAsync(_request);
        switch (result)
        {
            case LoginResponse response:
                snackbar.Add($"Welcome to Yes", MudBlazor.Severity.Success);
                break;
            case ValidationError validationError:
                foreach (var error in validationError.Errors) snackbar.Add(error, MudBlazor.Severity.Error, options => options.RequireInteraction = true);
                break;
            case EntityNotFoundError entityNotFoundError:
                snackbar.Add(entityNotFoundError.Message, MudBlazor.Severity.Error, options => options.RequireInteraction = true);
                break;
            case IncorrectPasswordError incorrectPasswordError:
                snackbar.Add(incorrectPasswordError.Message, MudBlazor.Severity.Error, options => options.RequireInteraction = true);
                break;
        }
    }
}
