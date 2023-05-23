using PartnerUp.Social.BusinessLogic.Common.Models.Requests;
using PartnerUp.Social.BusinessLogic.Common.Models.Responses;
using PartnerUp.Shared.Pagination;
using PartnerUp.Social.DataAccess.Common.Parameters;

namespace PartnerUp.Social.BusinessLogic.Interfaces.Services;

public interface IFriendsService
{
    Task<PagedList<UserResponse>> GetAsync(Guid userId, FriendsParameters parameters);
    Task AddToFriendsAsync(FriendsRequest request);
    Task DeleteFromFriendsAsync(FriendsRequest request);
}
