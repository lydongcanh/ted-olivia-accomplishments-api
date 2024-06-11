using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using TedOliviaAccomplishmentsApi.Core.Infrastructure.Database;
using TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.Entities;
using TedOliviaAccomplishmentsApi.Protobuf;

namespace TedOliviaAccomplishmentsApi.Core.Application.Services;

public class ProductivityLogService : IProductivityLogService
{
    public static readonly TimeSpan PingActiveDuration = TimeSpan.FromMinutes(2);
    
    private readonly AccomplishmentsDbContext _dbContext;

    public ProductivityLogService(AccomplishmentsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProductivityLogResponse> PingProductivityLogAsync(PingProductivityLogRequest request, CancellationToken cancellationToken)
    {
        var today = DateTimeOffset.UtcNow.Date;
        var owner = (Domain.Enums.Owner)request.Owner;
        var todayLog = await _dbContext.ProductivityLogs.FirstOrDefaultAsync(l => 
            l.CreatedDate.Date == today &&
            l.Type == request.Type &&
            l.Owner == owner, 
            cancellationToken);

        if (todayLog == default)
        {
            // Create a new log for the day.
            todayLog = new ProductivityLog
            {
                Note = request.Note,
                Type = request.Type,
                Owner = (Domain.Enums.Owner)request.Owner,
                IsActive = true,
                ActiveDuration = TimeSpan.Zero
            };
            _dbContext.Add(todayLog);
        }
        else
        {
            // Expand the existing log.
            if (!string.IsNullOrEmpty(request.Note))
            {
                todayLog.Note = request.Note;
            }

            todayLog.IsActive = true;
            todayLog.ActiveDuration = todayLog.ActiveDuration.Add(PingActiveDuration);
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new ProductivityLogResponse
        {
            Id = todayLog.Id,
            CreatedDate = Timestamp.FromDateTimeOffset(todayLog.CreatedDate),
            ModifiedDate = Timestamp.FromDateTimeOffset(todayLog.ModifiedDate),
            Note = todayLog.Note,
            Type = todayLog.Type,
            Owner = (Owner)todayLog.Owner,
            IsActive = todayLog.IsActive,
            ActiveDuration = Duration.FromTimeSpan(todayLog.ActiveDuration)
        };
    }
}