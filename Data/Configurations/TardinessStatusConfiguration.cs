using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheet.Model.Entity;

namespace TimeSheet.Data.Configurations
{
    public class TardinessStatusConfiguration : IEntityTypeConfiguration<TardinessStatus>
    {
        public void Configure(EntityTypeBuilder<TardinessStatus> builder)
        {
            builder.HasData(Seeds.TardinessStatuses);
        }
    }
}
