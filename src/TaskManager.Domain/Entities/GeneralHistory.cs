using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;

public class GeneralHistory
{
    public int Id { get; set; }
    public User User { get; set; } = null!;
    public GeneralHistoryAction Action { get; set; }
    public DateTime CreatedAt { get; set; }
}