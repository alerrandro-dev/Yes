namespace Yes.Shared.Requests.User;

public record UpdateUserRequest(string? Username, string? Email, string? Password);