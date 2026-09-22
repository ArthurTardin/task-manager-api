using TaskManager.Domain.Enums;

namespace TaskManager.Application.DTOs;

public record CreateTaskDto
{
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime StartDate { get; set; }
    public DateTime DueDate { get; set; }
    public TaskItemPriority Priority { get; set; }
    public int? AssigneeId { get; set; }
    public int ProjectId { get; set; }


}