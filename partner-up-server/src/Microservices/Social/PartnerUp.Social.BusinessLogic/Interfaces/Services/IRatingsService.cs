using PartnerUp.Social.BusinessLogic.Common.Models.Requests;
using PartnerUp.Social.BusinessLogic.Common.Models.Responses;
using PartnerUp.Shared.Pagination;
using PartnerUp.Social.DataAccess.Common.Parameters;

namespace PartnerUp.Social.BusinessLogic.Interfaces.Services;

public interface IRatingsService
{
    Task<IEnumerable<RatingResponse>> GetAsync();
    Task<PagedList<RatingResponse>> GetAsync(RatingsParameters parameters);
    Task<RatingResponse> GetByIdAsync(Guid id);
    Task InsertAsync(RatingRequest request);
    Task UpdateAsync(RatingRequest request);
    Task DeleteAsync(Guid id);
}
