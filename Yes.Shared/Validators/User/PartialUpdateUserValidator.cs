using FluentValidation;
using Yes.Shared.Errors.Field;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests.User;

namespace Yes.Shared.Validators.User;

public class PartialUpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    public PartialUpdateUserValidator()
    {
        RuleFor(r => r.Username)
            .MinimumLength(2).WithError(new FieldMinimumLengthError(nameof(UpdateUserRequest.Username), 2))
            .MaximumLength(150).WithError(new FieldMaximumLengthError(nameof(UpdateUserRequest.Username), 150));

        RuleFor(r => r.Email)
            .MinimumLength(5).WithError(new FieldMinimumLengthError(nameof(UpdateUserRequest.Email), 5))
            .MaximumLength(320).WithError(new FieldMaximumLengthError(nameof(UpdateUserRequest.Email), 320));

        RuleFor(r => r.Password)
            .MinimumLength(8).WithError(new FieldMinimumLengthError(nameof(UpdateUserRequest.Password), 8))
            .MaximumLength(16).WithError(new FieldMaximumLengthError(nameof(UpdateUserRequest.Password), 16));
    }
}
