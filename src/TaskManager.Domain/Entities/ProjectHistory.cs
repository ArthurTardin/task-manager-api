using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;

public class ProjectHistory
{
    public int Id { get; set; }
    public Project Project { get; set; } = null!;
    public User User { get; set; } = null!;
    public ProjectHistoryAction Action { get; set; }
    public DateTime CreatedAt { get; set; }
}