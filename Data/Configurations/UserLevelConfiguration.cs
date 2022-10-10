using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheet.Model.Entity;

namespace TimeSheet.Data.Configurations
{
    public class UserLevelConfiguration : IEntityTypeConfiguration<UserLevel>
    {
        public void Configure(EntityTypeBuilder<UserLevel> builder)
        {
            builder.HasData(Seeds.UserLevels);
        }
    }
}
