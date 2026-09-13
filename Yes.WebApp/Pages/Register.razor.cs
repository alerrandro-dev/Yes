using FluentValidation;
using MudBlazor;
using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests;
using Yes.Shared.Responses;
using Yes.Shared.Services;

namespace Yes.WebApp.Pages;

public partial class Register(IAuthenticationService authenticationService, ISnackbar snackbar, IValidator<RegisterRequest> validator)
{
    private RegisterRequest _request = new();

    private async Task SubmitAsync()
    {
        snackbar.Clear();

        var validationResult = await validator.ValidateAsync(_request);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.ErrorsToStringArray();
            foreach (var error in errors) snackbar.Add(error, MudBlazor.Severity.Error, options => options.RequireInteraction = true);

            return;
        }

        var result = await authenticationService.RegisterAsync(_request);

        switch (result)
        {
            case RegisterResponse response:
                snackbar.Add($"Welcome, {response.Username}", MudBlazor.Severity.Success);
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
