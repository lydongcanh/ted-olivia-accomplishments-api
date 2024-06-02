using Grpc.Core;
using TedOliviaAccomplishmentsApi.Core.Application.Services;
using TedOliviaAccomplishmentsApi.Protobuf;

namespace TedOliviaAccomplishmentsApi.ServiceHost.Services;

public class AccomplishmentService : Protobuf.AccomplishmentService.AccomplishmentServiceBase
{
    private readonly IAccomplishmentService _accomplishmentService;

    public AccomplishmentService(IAccomplishmentService accomplishmentService)
    {
        _accomplishmentService = accomplishmentService;
    }
    
    // TODO: Cancellation token
    public override async Task<AccomplishmentResponse> CreateAccomplishment(CreateAccomplishmentRequest request, ServerCallContext context)
    {
        return await _accomplishmentService.CreateAccomplishmentAsync(request);
    }
}