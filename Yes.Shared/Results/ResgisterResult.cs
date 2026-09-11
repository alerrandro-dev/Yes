using Yes.Shared.Errors;
using Yes.Shared.Errors.Entity;
using Yes.Shared.Responses;

namespace Yes.Shared.Results;

public union ResgisterResult(RegisterResponse, ValidationError, EntityAlreadyExistsError);