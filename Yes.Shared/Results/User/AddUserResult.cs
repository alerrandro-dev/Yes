using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Responses;

namespace Yes.Shared.Results.User;

public union AddUserResult(UserResponse, ValidationErrors, EntityAlreadyExists);