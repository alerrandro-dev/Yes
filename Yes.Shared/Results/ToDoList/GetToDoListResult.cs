using Yes.Shared.Errors.Entity;
using Yes.Shared.Responses;

namespace Yes.Shared.Results.ToDoList;

public union GetToDoListResult(ToDoListResponse, EntityNotFoundError);