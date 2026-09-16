namespace Yes.Shared.Errors.Field;

public record FieldMinimumLengthError(string Field, int Length) : Error($"Length of {Field} must be greater than or equal to {Length}");