using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces;

public interface IProjectRepository
{
   Task<Project?> GetById(int id);
}