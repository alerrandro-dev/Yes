using FluentValidation;
using Yes.Shared.Errors;

namespace Yes.Shared.Extensions.Validator;

public static class ValidatorWithErrorExtension
{
    extension<TEntity, TProperty>(IRuleBuilderOptions<TEntity, TProperty> ruleBuilderOptions)
    {
        public IRuleBuilderOptions<TEntity, TProperty> WithError(Error error)
        {
            ruleBuilderOptions.WithMessage(error.Message);

            return ruleBuilderOptions;
        }
    }
}
