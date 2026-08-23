namespace Yes.Shared.Errors.Entity;

public record EntityAlreadyExists(string entity, string field, object value) : Error($"{entity} with {field}: {value} already exists");