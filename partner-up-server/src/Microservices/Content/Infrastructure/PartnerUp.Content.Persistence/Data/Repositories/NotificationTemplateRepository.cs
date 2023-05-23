using PartnerUp.Content.Application.Interfaces.Data.Repositories;
using PartnerUp.Content.Domain.Entities;
using PartnerUp.Content.Domain.Enums;

namespace PartnerUp.Content.Persistence.Data.Repositories;

public class NotificationTemplateRepository : INotificationTemplateRepository
{
    private readonly ContentDbContext _dbContext;

    public NotificationTemplateRepository(ContentDbContext dbContext) => _dbContext = dbContext;

    public async Task<NotificationTemplate> GetByIdAsync(NotificationType id)
    {
        return (await _dbContext.NotificationTemplates.FindAsync(id))!;
    }
}
