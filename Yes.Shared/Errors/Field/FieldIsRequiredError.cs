namespace Yes.Shared.Errors.Field;

public record FieldIsRequiredError(string Field) : Error($"{Field} is required");
