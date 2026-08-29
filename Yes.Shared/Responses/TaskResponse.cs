namespace Yes.Shared.Responses;

public record TaskResponse(Guid Id, string Name, string? Description, bool IsCompleted);