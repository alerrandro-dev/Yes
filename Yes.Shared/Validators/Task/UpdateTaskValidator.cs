using FluentValidation;
using Yes.Shared.Errors.Field;
using Yes.Shared.Extensions.Validator;
using Yes.Shared.Requests.Task;

namespace Yes.Shared.Validators.Task;

public class UpdateTaskValidator : AbstractValidator<UpdateTaskRequest>
{
    public UpdateTaskValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(UpdateTaskRequest.Name)))
            .MinimumLength(2).WithError(new FieldMinimumLengthError(nameof(UpdateTaskRequest.Name), 2))
            .MaximumLength(150).WithError(new FieldMaximumLengthError(nameof(UpdateTaskRequest.Name), 150));


        RuleFor(r => r.Description)
            .MinimumLength(2).WithError(new FieldMinimumLengthError(nameof(UpdateTaskRequest.Description), 2))
            .MaximumLength(255).WithError(new FieldMaximumLengthError(nameof(UpdateTaskRequest.Description), 255));

        RuleFor(r => r.IsCompleted)
            .NotEmpty().WithError(new FieldIsRequiredError(nameof(UpdateTaskRequest.IsCompleted)));
    }
}
