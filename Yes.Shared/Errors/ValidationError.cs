namespace Yes.Shared.Errors;

public record ValidationError(string[] Errors) : Error(string.Join(". ", Errors));