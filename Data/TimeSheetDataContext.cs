using Microsoft.EntityFrameworkCore;
using TimeSheet.Data.Configurations;
using TimeSheet.Model.Entity;
using Task = TimeSheet.Model.Entity.Task;

namespace TimeSheet.Data
{
    public class TimeSheetDataContext : DbContext
    {
        public TimeSheetDataContext(DbContextOptions<TimeSheetDataContext> options) : base(options)
        {

        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tardiness> Tardinesses { get; set; }
        public DbSet<TardinessStatus> TardinessStatuses { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<TimeSheetLog> TimeSheetLogs { get; set; }
        public DbSet<TimeSheetLog> TimeSheetLogTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserLevel> UserLevels { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }
        public DbSet<UserType> UserTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectMemberConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectTaskConfiguration());
            modelBuilder.ApplyConfiguration(new BranchConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
            modelBuilder.ApplyConfiguration(new TaskTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserLevelConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserStatusConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TimeSheetLogTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TardinessStatusConfiguration());
            modelBuilder.ApplyConfiguration(new TimeSheetLogConfiguration());
            modelBuilder.ApplyConfiguration(new TardinessConfiguration());
        }
    }
}
