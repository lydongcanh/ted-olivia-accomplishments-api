using TedOliviaAccomplishmentsApi.Protobuf;

namespace TedOliviaAccomplishmentsApi.Core.Application.Services;

public interface IAccomplishmentService
{
    Task<AccomplishmentResponse> CreateAccomplishmentAsync(CreateAccomplishmentRequest request, CancellationToken cancellationToken);
}