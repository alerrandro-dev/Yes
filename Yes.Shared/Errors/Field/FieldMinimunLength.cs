namespace Yes.Shared.Errors.Field;

public record FieldMinimumLength(string field, int length) : Error($"Length of {field} must be bigger than {length}");