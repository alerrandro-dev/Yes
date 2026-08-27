namespace Yes.Shared.Requests.Task;

public record AddTaskRequest(string? Name, string? Description, Guid? ToDoListId);
