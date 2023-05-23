using MediatR;
using PartnerUp.Content.Application.Common.Models.Responses;

namespace PartnerUp.Content.Application.Features.Notifications.Queries.GetTopRecentNotifications;

public class GetTopRecentNotificationsQuery : IRequest<IEnumerable<NotificationResponse>>
{
    public Guid UserId { get; set; }
}
