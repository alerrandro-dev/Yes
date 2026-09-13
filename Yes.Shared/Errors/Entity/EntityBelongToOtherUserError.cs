namespace Yes.Shared.Errors.Entity;

public record EntityBelongToOtherUserError(string Entity, string Field, object Value) : Error($"{Entity} with {Field}: {Value} belong to other user");