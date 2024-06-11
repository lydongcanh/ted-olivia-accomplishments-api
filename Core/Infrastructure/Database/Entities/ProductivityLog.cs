using TedOliviaAccomplishmentsApi.Core.Domain.Enums;

namespace TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.Entities;

public record ProductivityLog : BaseEntity
{
    public string Type { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public Owner Owner { get; set; }
    public bool IsActive { get; set; }
    public TimeSpan ActiveDuration { get; set; }
}