using FluentValidation.Results;

namespace Yes.Shared.Extensions.Validator;

public static class ValidatorErrorsToStringArrayExtension
{
    extension(ValidationResult validationResult)
    {
        public string[] ErrorsToStringArray() => validationResult.Errors.Select(error => error.ErrorMessage).ToArray();
    }
}
