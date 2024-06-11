using Grpc.Core;
using TedOliviaAccomplishmentsApi.Core.Application.Services;
using TedOliviaAccomplishmentsApi.Protobuf;

namespace TedOliviaAccomplishmentsApi.ServiceHost.Services;

public class AccomplishmentService : Protobuf.AccomplishmentService.AccomplishmentServiceBase
{
    private readonly IAccomplishmentService _accomplishmentService;
    private readonly IProductivityLogService _productivityLogService;
    
    public AccomplishmentService(IAccomplishmentService accomplishmentService, IProductivityLogService productivityLogService)
    {
        _accomplishmentService = accomplishmentService;
        _productivityLogService = productivityLogService;
    }
    
    // TODO: Cancellation token
    public override async Task<AccomplishmentResponse> CreateAccomplishment(CreateAccomplishmentRequest request, ServerCallContext context)
    {
        return await _accomplishmentService.CreateAccomplishmentAsync(request, context.CancellationToken);
    }

    public override async Task<ProductivityLogResponse> PingProductivityLog(PingProductivityLogRequest request, ServerCallContext context)
    {
        return await _productivityLogService.PingProductivityLogAsync(request, context.CancellationToken);
    }
}