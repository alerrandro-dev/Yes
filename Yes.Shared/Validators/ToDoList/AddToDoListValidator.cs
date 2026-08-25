using FluentValidation;
using Yes.Shared.Errors.Field;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests.ToDoList;

namespace Yes.Shared.Validators.ToDoList;

public class AddToDoListValidator : AbstractValidator<AddToDoListRequest>
{
    public AddToDoListValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(AddToDoListRequest.Name)))
            .MinimumLength(2).WithError(new FieldMinimumLengthError(nameof(AddToDoListRequest.Name), 2))
            .MaximumLength(150).WithError(new FieldMaximumLengthError(nameof(AddToDoListRequest.Name), 150));

        RuleFor(r => r.UserId)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(AddToDoListRequest.UserId)));
    }
}
