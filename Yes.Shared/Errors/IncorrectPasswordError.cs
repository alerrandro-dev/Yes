namespace Yes.Shared.Errors;

public record IncorrectPasswordError(string password) : Error($"Password: {password} is incorrect");