using PartnerUp.Identity.People.BusinessLogic.Common.Models.Requests;
using PartnerUp.Identity.People.BusinessLogic.Common.Models.Responses;
using PartnerUp.Identity.Persistence.People.Common.Parameters;
using PartnerUp.Shared.Pagination;

namespace PartnerUp.Identity.People.BusinessLogic.Interfaces.Services;

public interface IUsersService
{
    Task<IEnumerable<UserResponse>> GetAsync();
    Task<PagedList<UserResponse>> GetAsync(UsersParameters parameters);
    Task<UserResponse> GetByIdAsync(Guid id);
    Task<UserResponse> UpdateAsync(UserRequest request);
    Task<string> SetAvatarForUserAsync(UserAvatarRequest request);
    Task DeleteAsync(Guid id);
}
