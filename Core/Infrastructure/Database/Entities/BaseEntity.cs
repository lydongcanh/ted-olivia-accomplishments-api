namespace TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.Entities;

public record BaseEntity
{
    public string Id { get; set; } = new Guid().ToString("N");
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset ModifiedDate { get; set; }
}