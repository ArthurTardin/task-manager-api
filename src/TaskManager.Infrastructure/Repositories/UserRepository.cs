
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TaskManagerDbContext _context;

    public UserRepository (TaskManagerDbContext context)
    {
        _context = context;
    }
    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);

        return user;
    }
}