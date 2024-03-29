﻿using PartnerUp.Content.Application.Interfaces.Data.Repositories;

namespace PartnerUp.Content.Application.Interfaces.Data;

public interface IUnitOfWork
{
    public INotificationRepository NotificationRepository { get; }
    public INotificationTemplateRepository NotificationTemplateRepository { get; }
    public IRecentRequestRepository RecentRequestRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
