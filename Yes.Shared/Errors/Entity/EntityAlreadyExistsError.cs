namespace Yes.Shared.Errors.Entity;

public record EntityAlreadyExistsError(string Entity, string Field, object Value) : Error($"{Entity} with {Field}: {Value} already exists");