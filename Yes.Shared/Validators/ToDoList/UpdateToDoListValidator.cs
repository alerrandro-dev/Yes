using FluentValidation;
using Yes.Shared.Errors.Field;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests.ToDoList;

namespace Yes.Shared.Validators.ToDoList;

public class UpdateToDoListValidator : AbstractValidator<UpdateToDoListRequest>
{
    public UpdateToDoListValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(UpdateToDoListRequest.Name)))
            .MinimumLength(2).WithError(new FieldMinimumLengthError(nameof(UpdateToDoListRequest.Name), 2))
            .MaximumLength(150).WithError(new FieldMaximumLengthError(nameof(UpdateToDoListRequest.Name), 150));
    }
}
