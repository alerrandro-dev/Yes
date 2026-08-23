namespace Yes.Shared.Errors.Field;

public record FieldMaximumLength(string field, int length) : Error($"Length of {field} must be lesser than {length}");