using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ProjectStatus Status { get; set; } = ProjectStatus.Scheduled;
    public User? Creator { get; set; }
    public int? CreatorId { get; set; }
    public List<TaskItem> Tasks { get; set; } = new();
}