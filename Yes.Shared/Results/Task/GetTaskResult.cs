using Yes.Shared.Errors.Entity;
using Yes.Shared.Responses;

namespace Yes.Shared.Results.Task;

public union GetTaskResult(TaskResponse, EntityNotFoundError, EntityBelongToOtherUserError);