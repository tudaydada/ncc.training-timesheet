using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TimeSheet.Data.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Model.Entity.Task>
    {
        public void Configure(EntityTypeBuilder<Model.Entity.Task> builder)
        {
            builder.HasData(Seeds.Tasks);
        }
    }
}
