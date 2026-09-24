using Yes.Shared.Responses;

namespace Yes.Shared.Contexts;

public interface IUserContext
{
    Guid Id { get; set; }
    UserResponse? Response { get; set; }
}
