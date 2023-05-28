using PartnerUp.WebClient.Parameters;
using PartnerUp.WebClient.ViewModels;

namespace PartnerUp.WebClient.Interfaces;

public interface IFriendsService
{
    Task<IEnumerable<UserViewModel>> GetFriendsAsync(Guid id);

    Task<(IEnumerable<UserViewModel>, PaginationHeaderViewModel)>
        GetFriendsWithPaginationHeaderAsync(Guid id, FriendsParameters parameters);

    Task AddFriendsAsync(FriendsViewModel viewModel);

    Task DeleteFriendsAsync(FriendsViewModel viewModel);
}
