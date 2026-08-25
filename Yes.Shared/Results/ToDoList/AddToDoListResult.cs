using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Responses;

namespace Yes.Shared.Results.ToDoList;

public union AddToDoListResult(ToDoListResponse, ValidationError, EntityNotFoundError, EntityFromOwnerEntityAlreadyExistsError);