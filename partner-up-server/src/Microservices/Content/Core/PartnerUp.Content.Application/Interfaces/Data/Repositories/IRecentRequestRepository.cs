using PartnerUp.Content.Domain.Entities;
using PartnerUp.Content.Domain.Enums;

namespace PartnerUp.Content.Application.Interfaces.Data.Repositories;

public interface IRecentRequestRepository
{
    Task<IEnumerable<RecentRequest>> GetAsync(Guid userId, RecentRequestEntityType type);
    Task InsertAsync(RecentRequest recentRequest);
}
