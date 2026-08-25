using Yes.Shared.Errors.Entity;

namespace Yes.Shared.Results.User;

public union DeleteUserResult(Success, EntityNotFoundError);