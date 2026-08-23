namespace Yes.Shared.Errors.Entity;

public record EntityNotFound(string entity, string field, object value) : Error($"{entity} with {field}: {value} not found");