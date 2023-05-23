using PartnerUp.Social.DataAccess.Common.Parameters;
using PartnerUp.Social.DataAccess.Data.Entities;
using PartnerUp.Shared.Pagination;

namespace PartnerUp.Social.DataAccess.Interfaces.Data.Repositories;

public interface IFriendsRepository
{
    Task<IEnumerable<UserProfile>> GetAsync(Guid userId);
    Task<PagedList<UserProfile>> GetAsync(Guid userId, FriendsParameters parameters);
    Task AddToFriendsAsync(Guid firstId, Guid secondId);
    Task DeleteFromFriendsAsync(Guid firstId, Guid secondId);
}
