using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;

public class GeneralHistory
{
    public int Id { get; set; }
    public User? User { get; set; }
    public int? UserId { get; set; }
    public GeneralHistoryAction Action { get; set; }
    public GeneralHistoryTargetType TargetType { get; set; }
    public int TargetId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}