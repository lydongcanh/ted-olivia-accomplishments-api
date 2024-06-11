using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.Entities;

namespace TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.EntityConfigs;

public class ProductivityLogConfig : BaseEntityConfig<ProductivityLog>
{
    public override void Configure(EntityTypeBuilder<ProductivityLog> builder)
    {
        base.Configure(builder);

        builder.Property(pl => pl.Note).IsRequired();
        builder.Property(pl => pl.Type).IsRequired();
        builder.Property(pl => pl.Owner).HasConversion<string>().IsRequired();
        builder.Property(pl => pl.LastActiveTime).IsRequired();
    }
}