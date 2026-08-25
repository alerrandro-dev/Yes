namespace Yes.Shared.Errors.Entity;

public record EntityFromOwnerEntityAlreadyExistsError(string entity, string field, object value, string ownerEntity, string ownerField, object ownerValue)
    : Error($"{entity} with {field}: {value} from {ownerEntity} with {ownerField}: {ownerValue} already exists");