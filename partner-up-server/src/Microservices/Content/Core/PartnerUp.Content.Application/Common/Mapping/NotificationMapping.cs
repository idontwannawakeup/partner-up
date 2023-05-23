using AutoMapper;
using PartnerUp.Content.Application.Common.Models.Responses;
using PartnerUp.Content.Application.Features.Notifications.Commands.SendNotification;
using PartnerUp.Content.Domain.Entities;

namespace PartnerUp.Content.Application.Common.Mapping;

public class NotificationMapping : Profile
{
    public NotificationMapping()
    {
        CreateMap<SendNotificationCommand, Notification>();
        CreateMap<Notification, NotificationResponse>();
    }
}
