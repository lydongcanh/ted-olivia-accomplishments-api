using Google.Protobuf.WellKnownTypes;
using TedOliviaAccomplishmentsApi.Core.Infrastructure.Database;
using TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.Entities;
using TedOliviaAccomplishmentsApi.Protobuf;
using Enum = System.Enum;

namespace TedOliviaAccomplishmentsApi.Core.Application.Services;

public class AccomplishmentService : IAccomplishmentService
{
    private readonly AccomplishmentsDbContext _dbContext;

    public AccomplishmentService(AccomplishmentsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // TODO: Auto mapping
    public async Task<AccomplishmentResponse> CreateAccomplishmentAsync(CreateAccomplishmentRequest request)
    {
        var accomplishment = new Accomplishment
        {
            Name = request.Name,
            Note = request.Note,
            Type = request.Type,
            Owner = (Domain.Enums.Owner)request.Owner,
            IsDone = request.IsDone
        };
        
        _dbContext.Add(accomplishment);
        await _dbContext.SaveChangesAsync();

        return new AccomplishmentResponse
        {
            Id = accomplishment.Id,
            CreatedDate = Timestamp.FromDateTimeOffset(accomplishment.CreatedDate),
            ModifiedDate = Timestamp.FromDateTimeOffset(accomplishment.ModifiedDate),
            Name = accomplishment.Name,
            Note = accomplishment.Note,
            Type = accomplishment.Type,
            Owner = (Owner)accomplishment.Owner,
            IsDone = accomplishment.IsDone
        };
    }
}