using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.Entities;

namespace TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.EntityConfigs;

public class AccomplishmentConfig : BaseEntityConfig<Accomplishment>
{
    public override void Configure(EntityTypeBuilder<Accomplishment> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Name).IsRequired();
        builder.Property(e => e.Owner).HasConversion<string>().IsRequired();
        builder.Property(e => e.Type).IsRequired();
    }
}