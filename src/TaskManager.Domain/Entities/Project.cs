using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime CreatedAt { get; set; }
    public ProjectStatus Status { get; set; }
    public User Creator { get; set; } = null!;
    public List<TaskItem> Tasks { get; set; } = new();
}