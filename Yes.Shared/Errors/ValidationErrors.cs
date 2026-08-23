namespace Yes.Shared.Errors;

public record ValidationErrors(string[] errors) : Error(string.Join('\n', errors));