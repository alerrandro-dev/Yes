namespace Yes.Shared.Errors;

public record ValidationError(string[] errors) : Error(string.Join('\n', errors));