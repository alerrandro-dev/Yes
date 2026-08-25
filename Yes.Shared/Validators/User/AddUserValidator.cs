using FluentValidation;
using Yes.Shared.Errors.Field;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests.User;

namespace Yes.Shared.Validators.User;

public class AddUserValidator : AbstractValidator<AddUserRequest>
{
    public AddUserValidator()
    {
        RuleFor(r => r.Username)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(AddUserRequest.Username)))
            .MinimumLength(2).WithError(new FieldMinimumLengthError(nameof(AddUserRequest.Username), 2))
            .MaximumLength(150).WithError(new FieldMaximumLengthError(nameof(AddUserRequest.Username), 150));

        RuleFor(r => r.Email)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(AddUserRequest.Email)))
            .MinimumLength(5).WithError(new FieldMinimumLengthError(nameof(AddUserRequest.Email), 5))
            .MaximumLength(320).WithError(new FieldMaximumLengthError(nameof(AddUserRequest.Email), 320));

        RuleFor(r => r.Password)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(AddUserRequest.Password)))
            .MinimumLength(8).WithError(new FieldMinimumLengthError(nameof(AddUserRequest.Password), 8))
            .MaximumLength(16).WithError(new FieldMaximumLengthError(nameof(AddUserRequest.Password), 16));
    }
}
