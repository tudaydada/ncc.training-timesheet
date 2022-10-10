using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheet.Model.Entity;

namespace TimeSheet.Data.Configurations
{
    public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
    {
        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            builder.HasKey(e => new { e.ProjectId, e.TaskId });
            builder.HasData(Seeds.ProjectTasks);
        }
    }
}
