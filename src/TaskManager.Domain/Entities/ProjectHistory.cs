using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;

public class ProjectHistory
{
    public int Id { get; set; }
    public Project Project { get; set; } = null!;
    public int ProjectId { get; set; }
    public User? Actor { get; set; } = null!;
    public int? ActorId { get; set; }
    public ProjectHistoryAction Action { get; set; }
    public ProjectHistoryTargetType TargetType { get; set; }
    public int TargetId { get; set; }
    public User? Subject { get; set; }
    public int? SubjectId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}