using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.Entities;

namespace TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.EntityConfigs;

public class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity 
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.CreatedDate).IsRequired();
        builder.Property(e => e.ModifiedDate).IsRequired();
    }
}