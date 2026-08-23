namespace Yes.Shared.Errors.Field;

public record FieldIsRequired(string field) : Error($"{field} is required");
