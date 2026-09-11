using Yes.Shared.Errors.Entity;

namespace Yes.Shared.Results.Task;

public union DeleteTaskResult(Success, EntityNotFoundError, EntityBelongToOtherUserError);