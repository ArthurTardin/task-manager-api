using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IUnitOfWork _unitOfWork;

    public TaskService(
        ITaskRepository taskRepository,
        IProjectRepository projectRepository,
        IUserRepository userRepository,
        ICurrentUserService currentUserService,
        IUnitOfWork unitOfWork)
    {
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
        _userRepository = userRepository;
        _currentUserService = currentUserService;
        _unitOfWork = unitOfWork;
    }
    public async Task<TaskDto> CreateTask(CreateTaskDto dto)
    {
        var project = await _projectRepository.GetByIdAsync(dto.ProjectId);

        if (project is null)
        {
            throw new InvalidOperationException("Project not found.");
        }

        User? assignee = null;

        if (dto.AssigneeId.HasValue)
        {
            assignee = await _userRepository.GetByIdAsync(dto.AssigneeId.Value);

            if (assignee is null)
            {
                throw new InvalidOperationException("Assignee not found.");
            }
        }

        var creatorId = _currentUserService.UserId;
        var creator = await _userRepository.GetByIdAsync(creatorId);

        if (creator is null)
        {
            throw new InvalidOperationException("There is no creator.");
        }

        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            StartDate = dto.StartDate.UtcDateTime,
            DueDate = dto.DueDate.UtcDateTime,
            Priority = dto.Priority,
            Assignee = assignee,
            Creator = creator,
            Project = project, 
        };

        _taskRepository.Add(task);
        await _unitOfWork.SaveChangesAsync();
        var taskDto = new TaskDto
        {
            Id = task.Id,
            Status = task.Status,
            Title = task.Title,
            Description = task.Description,
            StartDate = task.StartDate,
            DueDate = task.DueDate,
            Priority = task.Priority,
            AssigneeId = assignee?.Id,
            CreatorId = creator.Id,
            ProjectId = project.Id     
        };

        return taskDto;
    }
}