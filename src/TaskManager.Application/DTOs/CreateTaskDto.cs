using TaskManager.Domain.Enums;

namespace TaskManager.Application.DTOs;

public record CreateTaskDto
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset DueDate { get; set; }
    public TaskItemPriority Priority { get; set; }
    public int? AssigneeId { get; set; }
    public int ProjectId { get; set; }


}