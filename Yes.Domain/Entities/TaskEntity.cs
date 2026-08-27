namespace Yes.Domain.Entities;

public class TaskEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }

    public Guid ToDoListId { get; set; }
    public ToDoListEntity ToDoList { get; set; }
}
