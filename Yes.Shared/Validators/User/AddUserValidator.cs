using FluentValidation;
using Yes.Shared.Errors.Field;
using Yes.Shared.Requests.User;
using Yes.Shared.Validators.Extension;

namespace Yes.Shared.Validators.User;

public class AddUserValidator : AbstractValidator<AddUserRequest>
{
    public AddUserValidator()
    {
        RuleFor(r => r.Username)
            .NotEmpty().WithError(new FieldIsRequired(nameof(AddUserRequest.Username)))
            .MinimumLength(2).WithError(new FieldMinimumLength(nameof(AddUserRequest.Username), 2))
            .MaximumLength(150).WithError(new FieldMaximumLength(nameof(AddUserRequest.Username), 150));

        RuleFor(r => r.Email)
            .NotEmpty().WithError(new FieldIsRequired(nameof(AddUserRequest.Email)))
            .MinimumLength(5).WithError(new FieldMinimumLength(nameof(AddUserRequest.Email), 5))
            .MaximumLength(320).WithError(new FieldMaximumLength(nameof(AddUserRequest.Email), 320));

        RuleFor(r => r.Password)
            .NotEmpty().WithError(new FieldIsRequired(nameof(AddUserRequest.Password)))
            .MinimumLength(8).WithError(new FieldMinimumLength(nameof(AddUserRequest.Password), 8))
            .MaximumLength(16).WithError(new FieldMaximumLength(nameof(AddUserRequest.Password), 16));
    }
}
