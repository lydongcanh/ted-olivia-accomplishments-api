namespace TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.Entities;

public record BaseEntity
{
    public string Id { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset ModifiedDate { get; set; }
}