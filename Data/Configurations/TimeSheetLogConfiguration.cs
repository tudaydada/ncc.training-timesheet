using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheet.Model.Entity;

namespace TimeSheet.Data.Configurations
{
    public class TimeSheetLogConfiguration : IEntityTypeConfiguration<TimeSheetLog>
    {
        public void Configure(EntityTypeBuilder<TimeSheetLog> builder)
        {
            builder.HasData(Seeds.TimeSheetLogs);
        }
    }
}
