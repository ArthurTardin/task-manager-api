using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Data;

public class TaskManagerDbContext : DbContext
{
    public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
    public DbSet<ProjectMember> ProjectMembers { get; set; }
    public DbSet<GeneralHistory> GeneralHistories { get; set; }
    public DbSet<ProjectHistory> ProjectHistories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<Project>()
            .HasMany(project => project.Tasks)
            .WithOne(task => task.Project)
            .HasForeignKey(task => task.ProjectId);

        modelBuilder.Entity<TaskItem>()
            .HasOne(task => task.Creator)
            .WithMany()
            .HasForeignKey(task => task.CreatorId);
        
        modelBuilder.Entity<TaskItem>()
            .HasOne(task => task.Assignee)
            .WithMany()
            .HasForeignKey(task => task.AssigneeId);
        
        modelBuilder.Entity<TaskItem>()
            .HasMany(task => task.Contributors)
            .WithMany();
    }
}