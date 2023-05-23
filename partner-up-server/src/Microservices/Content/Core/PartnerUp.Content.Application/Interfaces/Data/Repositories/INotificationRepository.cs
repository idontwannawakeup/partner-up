using PartnerUp.Content.Domain.Entities;

namespace PartnerUp.Content.Application.Interfaces.Data.Repositories;

public interface INotificationRepository
{
    Task<IEnumerable<Notification>> GetAsync(Guid userId);
    Task<IEnumerable<Notification>> GetTopRecentAsync(Guid userId);
    Task<Notification> InsertAsync(Notification notification);
    Task DeleteAsync(Guid id);
}
