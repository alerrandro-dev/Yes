using FluentValidation;
using Yes.Shared.Errors.Field;
using Yes.Shared.Requests.User;
using Yes.Shared.Validators.Extension;

namespace Yes.Shared.Validators.User;

public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserValidator()
    {
        RuleFor(r => r.Username)
            .NotEmpty().WithError(new FieldIsRequired(nameof(UpdateUserRequest.Username)))
            .MinimumLength(2).WithError(new FieldMinimumLength(nameof(UpdateUserRequest.Username), 2))
            .MaximumLength(150).WithError(new FieldMaximumLength(nameof(UpdateUserRequest.Username), 150));

        RuleFor(r => r.Email)
            .NotEmpty().WithError(new FieldIsRequired(nameof(UpdateUserRequest.Email)))
            .MinimumLength(5).WithError(new FieldMinimumLength(nameof(UpdateUserRequest.Email), 5))
            .MaximumLength(320).WithError(new FieldMaximumLength(nameof(UpdateUserRequest.Email), 320));

        RuleFor(r => r.Password)
            .NotEmpty().WithError(new FieldIsRequired(nameof(UpdateUserRequest.Password)))
            .MinimumLength(8).WithError(new FieldMinimumLength(nameof(UpdateUserRequest.Password), 8))
            .MaximumLength(16).WithError(new FieldMaximumLength(nameof(UpdateUserRequest.Password), 16));
    }
}