using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheet.Model.Entity;

namespace TimeSheet.Data.Configurations
{
    public class TimeSheetLogTypeConfiguration : IEntityTypeConfiguration<TimeSheetLogType>
    {
        public void Configure(EntityTypeBuilder<TimeSheetLogType> builder)
        {
            builder.HasData(Seeds.TimeSheetLogTypes);
        }
    }
}
