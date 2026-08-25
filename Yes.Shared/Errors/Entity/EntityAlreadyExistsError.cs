namespace Yes.Shared.Errors.Entity;

public record EntityAlreadyExistsError(string entity, string field, object value) : Error($"{entity} with {field}: {value} already exists");