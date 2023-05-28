﻿using Microsoft.AspNetCore.Components.Forms;
using PartnerUp.WebClient.Parameters;
using PartnerUp.WebClient.ViewModels;

namespace PartnerUp.WebClient.Interfaces;

public interface IUsersService
{
    Task<IEnumerable<UserViewModel>> GetAsync(UsersParameters parameters);

    Task<(IEnumerable<UserViewModel>, PaginationHeaderViewModel)> GetWithPaginationHeaderAsync(
        UsersParameters parameters);

    Task<IEnumerable<UserViewModel>> GetAsync();

    Task<IEnumerable<UserViewModel>> GetByTeamIdAsync(Guid teamId);

    Task<UserViewModel> GetByIdAsync(Guid id);

    Task UpdateAsync(UserViewModel viewModel);

    Task SetAvatarForUserAsync(Guid id, IBrowserFile file);

    Task DeleteAsync(Guid userId);
}
