using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheet.Model.Entity;

namespace TimeSheet.Data.Configurations
{
    public class ProjectMemberConfiguration : IEntityTypeConfiguration<ProjectMember>
    {
        public void Configure(EntityTypeBuilder<ProjectMember> builder)
        {
            builder.HasKey(e => new { e.ProjectId, e.UserId });
            builder.HasData(Seeds.ProjectMembers);
        }
    }
}
