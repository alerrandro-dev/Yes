using FluentValidation;
using Yes.Shared.Errors.Field;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests;

namespace Yes.Shared.Validators;

public class RegisterValidator : AbstractValidator<RegisterRequest>
{
    public RegisterValidator()
    {
        RuleFor(r => r.Username)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(RegisterRequest.Username)))
            .MinimumLength(2).WithError(new FieldMinimumLengthError(nameof(RegisterRequest.Username), 2))
            .MaximumLength(150).WithError(new FieldMaximumLengthError(nameof(RegisterRequest.Username), 150));

        RuleFor(r => r.Email)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(RegisterRequest.Email)))
            .MinimumLength(5).WithError(new FieldMinimumLengthError(nameof(RegisterRequest.Email), 5))
            .MaximumLength(320).WithError(new FieldMaximumLengthError(nameof(RegisterRequest.Email), 320));

        RuleFor(r => r.Password)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(RegisterRequest.Password)))
            .MinimumLength(8).WithError(new FieldMinimumLengthError(nameof(RegisterRequest.Password), 8))
            .MaximumLength(16).WithError(new FieldMaximumLengthError(nameof(RegisterRequest.Password), 16));
    }
}
