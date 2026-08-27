namespace Yes.Shared.Responses;

public record ToDoListResponse(Guid Id, string Name, TaskResponse[] Tasks);