using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskManagerDbContext _context;

    public TaskRepository (TaskManagerDbContext context)
    {
        _context = context;
    }
    public void Add(TaskItem taskItem)
    {
        _context.Tasks.Add(taskItem);
    }
}