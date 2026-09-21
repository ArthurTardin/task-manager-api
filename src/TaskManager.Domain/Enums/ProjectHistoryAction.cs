namespace TaskManager.Domain.Enums;

public enum ProjectHistoryAction
{
    Undefined = 0,
    MemberAdded = 1,
    MemberRemoved = 2,
    TaskCreated = 3,
    TaskUpdated = 4,
    TaskDeleted = 5,
    TaskAssigned = 6,
    TaskAssignmentChanged = 7,
    TaskStatusChanged = 8
}