using FluentValidation;
using Yes.Shared.Errors.Field;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests.Task;

namespace Yes.Shared.Validators.Task;

public class AddTaskValidator : AbstractValidator<AddTaskRequest>
{
    public AddTaskValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(AddTaskRequest.Name)))
            .MinimumLength(2).WithError(new FieldMinimumLengthError(nameof(AddTaskRequest.Name), 2))
            .MaximumLength(150).WithError(new FieldMaximumLengthError(nameof(AddTaskRequest.Name), 150));


        RuleFor(r => r.Description)
            .MinimumLength(2).WithError(new FieldMinimumLengthError(nameof(AddTaskRequest.Description), 2))
            .MaximumLength(255).WithError(new FieldMaximumLengthError(nameof(AddTaskRequest.Description), 255));

        RuleFor(r => r.ToDoListId)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(AddTaskRequest.ToDoListId)));
    }
}
