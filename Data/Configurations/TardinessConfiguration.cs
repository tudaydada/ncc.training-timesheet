using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheet.Model.Entity;

namespace TimeSheet.Data.Configurations
{
    public class TardinessConfiguration : IEntityTypeConfiguration<Tardiness>
    {
        public void Configure(EntityTypeBuilder<Tardiness> builder)
        {
            builder.HasData(Seeds.Tardinesses);
        }
    }
}
