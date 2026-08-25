namespace Yes.Domain.Entities;

public class ToDoListEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
}
