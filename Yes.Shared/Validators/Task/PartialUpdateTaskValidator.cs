using FluentValidation;
using Yes.Shared.Errors.Field;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests.Task;

namespace Yes.Shared.Validators.Task;

public class PartialUpdateTaskValidator : AbstractValidator<UpdateTaskRequest>
{
    public PartialUpdateTaskValidator()
    {
        RuleFor(r => r.Name)
            .MinimumLength(2).WithError(new FieldMinimumLengthError(nameof(UpdateTaskRequest.Name), 2))
            .MaximumLength(150).WithError(new FieldMaximumLengthError(nameof(UpdateTaskRequest.Name), 150));

        RuleFor(r => r.Description)
            .MinimumLength(2).WithError(new FieldMinimumLengthError(nameof(UpdateTaskRequest.Description), 2))
            .MaximumLength(255).WithError(new FieldMaximumLengthError(nameof(UpdateTaskRequest.Description), 255));
    }
}
