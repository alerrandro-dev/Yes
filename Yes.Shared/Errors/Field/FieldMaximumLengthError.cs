namespace Yes.Shared.Errors.Field;

public record FieldMaximumLengthError(string Field, int Length) : Error($"Length of {Field} must be less than or equal to {Length}");