using FluentValidation;
using MudBlazor;
using Yes.Shared.Extensions.Validator;

namespace Yes.WebApp.Extensions;

public static class IsValidBeforeSedingRequestExtension
{
    extension<T>(T value)
    {
        public async Task<bool> IsValidBeforeSedingRequestAsync(IValidator<T> validator, ISnackbar snackbar)
        {
            var validationResult = await validator.ValidateAsync(value);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.ErrorsToStringArray();
                foreach (var error in errors) snackbar.Add(error, MudBlazor.Severity.Error, options => options.RequireInteraction = true);
            }

            return validationResult.IsValid;
        }
    }
}
