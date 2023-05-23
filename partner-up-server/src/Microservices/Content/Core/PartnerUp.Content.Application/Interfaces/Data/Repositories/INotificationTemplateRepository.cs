using PartnerUp.Content.Domain.Entities;
using PartnerUp.Content.Domain.Enums;

namespace PartnerUp.Content.Application.Interfaces.Data.Repositories;

public interface INotificationTemplateRepository
{
    Task<NotificationTemplate> GetByIdAsync(NotificationType id);
}
