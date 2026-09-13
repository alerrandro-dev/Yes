namespace Yes.Shared.Errors.Field;

public record FieldMaximumLengthError(string Field, int Length) : Error($"Length of {Field} must be lesser than {Length}");