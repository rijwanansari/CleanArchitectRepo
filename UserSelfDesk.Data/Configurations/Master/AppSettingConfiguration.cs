using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UserSelfDesk.Domain.Master;

namespace UserSelfDesk.Data.Configurations.Master
{
    public class AppSettingConfiguration : IEntityTypeConfiguration<AppSetting>
    {
        public void Configure(EntityTypeBuilder<AppSetting> builder)
        {
            builder
                .ToTable(nameof(AppSetting));
            builder.Property(nameof(AppSetting.ReferenceKey)).HasMaxLength(100).IsRequired();
            builder.Property(nameof(AppSetting.Value)).HasMaxLength(250);
            builder.Property(nameof(AppSetting.Description)).HasMaxLength(250).IsRequired();
            builder.Property(nameof(AppSetting.Type)).HasMaxLength(50).IsRequired();
        }
    }
}
