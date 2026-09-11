using FluentValidation;
using Yes.Shared.Errors.Field;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests;

namespace Yes.Shared.Validators;

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(r => r.Email)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(LoginRequest.Email)))
            .MinimumLength(5).WithError(new FieldMinimumLengthError(nameof(LoginRequest.Email), 5))
            .MaximumLength(320).WithError(new FieldMaximumLengthError(nameof(LoginRequest.Email), 320));

        RuleFor(r => r.Password)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(LoginRequest.Password)))
            .MinimumLength(8).WithError(new FieldMinimumLengthError(nameof(LoginRequest.Password), 8))
            .MaximumLength(16).WithError(new FieldMaximumLengthError(nameof(LoginRequest.Password), 16));
    }
}