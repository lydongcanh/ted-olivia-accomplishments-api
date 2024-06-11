using TedOliviaAccomplishmentsApi.Protobuf;

namespace TedOliviaAccomplishmentsApi.Core.Application.Services;

public interface IProductivityLogService
{
    Task<ProductivityLogResponse> PingProductivityLogAsync(PingProductivityLogRequest request, CancellationToken cancellationToken);
}