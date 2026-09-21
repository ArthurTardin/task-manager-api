using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;
public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
    public  TaskItemStatus Status { get; set; }
    public TaskItemPriority Priority { get; set; }
    public User Creator { get; set; } = null!;
    public User? Assignee { get; set; }
    public List<User> Contributors { get; set; } = new();
    public Project Project { get; set; } = null!;
}