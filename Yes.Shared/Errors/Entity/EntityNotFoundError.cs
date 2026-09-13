namespace Yes.Shared.Errors.Entity;

public record EntityNotFoundError(string Entity, string Field, object Value) : Error($"{Entity} with {Field}: {Value} not found");