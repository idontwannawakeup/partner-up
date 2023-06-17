using PartnerUp.Social.DataAccess.Common.Parameters;
using PartnerUp.Social.DataAccess.Data.Entities;
using PartnerUp.Shared.Interfaces;
using PartnerUp.Shared.Pagination;

namespace PartnerUp.Social.DataAccess.Interfaces.Data.Repositories;

public interface IRatingsRepository : IRepository<Rating>
{
    Task<PagedList<Rating>> GetAsync(RatingsParameters parameters);
    Task<IEnumerable<Rating>> GetRatingsFromUserAsync(Guid userId);
    Task<IEnumerable<Rating>> GetRatingsForUserAsync(Guid userId);
}
