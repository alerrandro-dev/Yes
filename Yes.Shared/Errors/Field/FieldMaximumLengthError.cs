namespace Yes.Shared.Errors.Field;

public record FieldMaximumLengthError(string field, int length) : Error($"Length of {field} must be lesser than {length}");