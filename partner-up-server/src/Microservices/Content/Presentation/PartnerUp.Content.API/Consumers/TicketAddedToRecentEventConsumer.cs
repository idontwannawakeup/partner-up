using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
using PartnerUp.Content.Application.Interfaces.Data;
using PartnerUp.Content.Domain.Entities;
using PartnerUp.Content.Domain.Enums;
using PartnerUp.EventBus.Messages.RecentEvents;

namespace PartnerUp.Content.API.Consumers;

public class TicketAddedToRecentEventConsumer : IConsumer<TicketAddedToRecentEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDistributedCache _cache;

    public TicketAddedToRecentEventConsumer(IUnitOfWork unitOfWork, IDistributedCache cache)
    {
        _unitOfWork = unitOfWork;
        _cache = cache;
    }

    public async Task Consume(ConsumeContext<TicketAddedToRecentEvent> context)
    {
        await _unitOfWork.RecentRequestRepository.InsertAsync(new RecentRequest
        {
            UserProfileId = context.Message.UserId,
            RequestedEntityId = context.Message.TicketId,
            RecentRequestEntityType = RecentRequestEntityType.Ticket,
            RequestedAt = DateTime.Now
        });

        await _unitOfWork.SaveChangesAsync();
        await _cache.RemoveAsync($"{context.Message.UserId}-{RecentRequestEntityType.Ticket}");
    }
}
