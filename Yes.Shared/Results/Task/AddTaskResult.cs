using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Responses;

namespace Yes.Shared.Results.Task;

public union AddTaskResult(TaskResponse, ValidationError, EntityNotFoundError, EntityBelongToOtherUserError, EntityFromOwnerEntityAlreadyExistsError);