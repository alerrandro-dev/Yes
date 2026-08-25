using FluentValidation;
using Yes.Shared.Errors.Field;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests.User;

namespace Yes.Shared.Validators.User;

public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(r => r.Username)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(UpdateUserRequest.Username)))
            .MinimumLength(2).WithError(new FieldMinimumLengthError(nameof(UpdateUserRequest.Username), 2))
            .MaximumLength(150).WithError(new FieldMaximumLengthError(nameof(UpdateUserRequest.Username), 150));

        RuleFor(r => r.Email)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(UpdateUserRequest.Email)))
            .MinimumLength(5).WithError(new FieldMinimumLengthError(nameof(UpdateUserRequest.Email), 5))
            .MaximumLength(320).WithError(new FieldMaximumLengthError(nameof(UpdateUserRequest.Email), 320));

        RuleFor(r => r.Password)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(UpdateUserRequest.Password)))
            .MinimumLength(8).WithError(new FieldMinimumLengthError(nameof(UpdateUserRequest.Password), 8))
            .MaximumLength(16).WithError(new FieldMaximumLengthError(nameof(UpdateUserRequest.Password), 16));
    }
}