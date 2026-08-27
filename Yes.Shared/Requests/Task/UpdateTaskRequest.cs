namespace Yes.Shared.Requests.Task;

public record UpdateTaskRequest(string? Name, string? Description, bool? IsCompleted);