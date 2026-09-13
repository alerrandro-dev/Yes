namespace Yes.Shared.Errors.Entity;

public record EntityFromOwnerEntityAlreadyExistsError(string Entity, string Field, object Value, string OwnerEntity, string OwnerField,
    object OwnerValue) : Error($"{Entity} with {Field}: {Value} from {OwnerEntity} with {OwnerField}: {OwnerValue} already exists");