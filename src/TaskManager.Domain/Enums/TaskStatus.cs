namespace TaskManager.Domain.Enums;

public enum TaskItemStatus
{
    Backlog = 1,
    Scheduled = 2,
    Todo = 3,
    InProgress = 4,
    Blocked = 5,
    Completed = 6,
    Cancelled = 7
}