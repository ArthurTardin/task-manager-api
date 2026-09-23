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

        modelBuilder.Entity<Project>()
            .HasOne(project => project.Creator)
            .WithMany()
            .HasForeignKey(project => project.CreatorId)
            .OnDelete(DeleteBehavior.SetNull);

            

        modelBuilder.Entity<TaskItem>()
            .HasOne(task => task.Creator)
            .WithMany()
            .HasForeignKey(task => task.CreatorId)
            .OnDelete(DeleteBehavior.Restrict);

        
        modelBuilder.Entity<TaskItem>()
            .HasOne(task => task.Assignee)
            .WithMany()
            .HasForeignKey(task => task.AssigneeId)
            .OnDelete(DeleteBehavior.SetNull);

        
        modelBuilder.Entity<TaskItem>()
            .HasMany(task => task.Contributors)
            .WithMany();


        modelBuilder.Entity<TaskItem>()
            .HasIndex(taskItem => taskItem.ProjectId);

        modelBuilder.Entity<TaskItem>()
            .HasIndex(taskItem => taskItem.AssigneeId);


        
        modelBuilder.Entity<ProjectMember>()
            .HasOne(projectMember => projectMember.User)
            .WithMany()
            .HasForeignKey(projectMember => projectMember.UserId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<ProjectMember>()
            .HasOne(projectMember => projectMember.Project)
            .WithMany()
            .HasForeignKey(projectMember => projectMember.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<ProjectMember>()
            .HasIndex(projectMember => new {projectMember.ProjectId, projectMember.UserId})
            .IsUnique();



        modelBuilder.Entity<GeneralHistory>()
            .HasOne(generalHistory => generalHistory.User)
            .WithMany()
            .HasForeignKey(generalHistory => generalHistory.UserId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<GeneralHistory>()
            .HasIndex(generalHistory => new { generalHistory.UserId, generalHistory.CreatedAt });

        

        modelBuilder.Entity<ProjectHistory>()
            .HasOne(projectHistory => projectHistory.Project)
            .WithMany()
            .HasForeignKey(projectHistory => projectHistory.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProjectHistory>()
            .HasOne(projectHistory => projectHistory.Actor)
            .WithMany()
            .HasForeignKey(projectHistory => projectHistory.ActorId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<ProjectHistory>()
            .HasOne(projectHistory => projectHistory.Subject)
            .WithMany()
            .HasForeignKey(projectHistory => projectHistory.SubjectId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<ProjectHistory>()
            .HasIndex(projectHistory => new {projectHistory.ProjectId, projectHistory.CreatedAt});


        modelBuilder.Entity<User>()
            .HasIndex(user => user.Email)
            .IsUnique();
    }
}