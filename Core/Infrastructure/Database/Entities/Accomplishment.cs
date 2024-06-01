using TedOliviaAccomplishmentsApi.Core.Domain.Enums;

namespace TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.Entities;

public record Accomplishment : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public Owner Owner { get; set; }
    public bool IsDone { get; set; }
}