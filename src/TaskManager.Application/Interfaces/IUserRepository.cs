using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetById(int id);
}