using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserSelfDesk.Domain.Master;

namespace UserSelfDesk.Data.Configurations.Master
{
    public class ReferenceMasterConfiguration : IEntityTypeConfiguration<ReferenceMaster>
    {
        public void Configure(EntityTypeBuilder<ReferenceMaster> builder)
        {
            builder
                .ToTable(nameof(ReferenceMaster));
            builder.Property(nameof(ReferenceMaster.Title)).HasMaxLength(100).IsRequired();
            builder.Property(nameof(ReferenceMaster.Description)).HasMaxLength(250);
            builder.Property(nameof(ReferenceMaster.RefCode)).HasMaxLength(50).IsRequired();
        }
    }
}
