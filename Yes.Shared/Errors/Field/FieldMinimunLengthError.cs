namespace Yes.Shared.Errors.Field;

public record FieldMinimumLengthError(string Field, int Length) : Error($"Length of {Field} must be bigger than {Length}");