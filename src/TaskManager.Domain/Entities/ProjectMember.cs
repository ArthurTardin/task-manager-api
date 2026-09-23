using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities;

public class ProjectMember
{
    public int Id { get; set; }
    public User User { get; set; } = null!;
    public Project Project { get; set; } = null!;
    public ProjectMemberRole Role { get; set; } = ProjectMemberRole.Member;
    public int UserId { get; set; }
    public int ProjectId { get; set; }
}