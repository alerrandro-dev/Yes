using Yes.Shared.Errors.Entity;

namespace Yes.Shared.Results.ToDoList;

public union DeleteToDoListResult(Success, EntityNotFoundError);