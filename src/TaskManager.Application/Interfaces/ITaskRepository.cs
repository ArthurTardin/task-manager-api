using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces;

public interface ITaskRepository
{
    void Add (TaskItem task);
}
