
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly TaskManagerDbContext _context;

    public ProjectRepository (TaskManagerDbContext context)
    {
        _context = context;
    }
   public async Task<Project?> GetByIdAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);

        return project;
        
    }
}