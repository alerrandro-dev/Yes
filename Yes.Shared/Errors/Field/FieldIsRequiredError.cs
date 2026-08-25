namespace Yes.Shared.Errors.Field;

public record FieldIsRequiredError(string field) : Error($"{field} is required");
