using MediatR;
using PartnerUp.Content.Application.Common.Models.Responses;

namespace PartnerUp.Content.Application.Features.Notifications.Queries.GetNotifications;

public class GetNotificationsQuery : IRequest<IEnumerable<NotificationResponse>>
{
    public Guid UserId { get; set; }
}
