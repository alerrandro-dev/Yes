namespace Yes.Shared.Responses;

public record UserResponse(Guid Id, string Username, string Email, ToDoListResponse[] ToDoLists);