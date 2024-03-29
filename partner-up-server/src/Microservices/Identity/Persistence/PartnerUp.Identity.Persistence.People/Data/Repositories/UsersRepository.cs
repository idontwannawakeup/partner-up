using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PartnerUp.Identity.Persistence.People.Common.Parameters;
using PartnerUp.Identity.Persistence.People.Data.Entities;
using PartnerUp.Identity.Persistence.People.Interfaces.Data.Repositories;
using PartnerUp.Shared.Exceptions;
using PartnerUp.Shared.Extensions;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.Shared.Pagination;

namespace PartnerUp.Identity.Persistence.People.Data.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly UserManager<User> _userManager;
    private readonly IFilterFactory<User> _filter;

    public UsersRepository(UserManager<User> userManager, IFilterFactory<User> filter)
    {
        _userManager = userManager;
        _filter = filter;
    }

    public async Task<IEnumerable<User>> GetAsync()
    {
        return await _userManager.Users.ToListAsync();
    }

    public async Task<PagedList<User>> GetAsync(UsersParameters parameters)
    {
        // var source = _userManager.Users.FilterBy(new LastNameCriterion(parameters));
        var source = _userManager.Users.FilterWith(_filter.Get(parameters));
        return await PagedList<User>.ToPagedListAsync(
            source,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        return user ?? throw new EntityNotFoundException(GetUserNotFoundErrorMessage(id));
    }

    public async Task<User> FindByNameOrThrowAsync(string name)
    {
        var user = await _userManager.FindByNameAsync(name);
        return user ?? throw new EntityNotFoundException(
            $"{nameof(User)} with user name {name} not found.");
    }

    public async Task<User> GetCompleteEntityAsync(Guid id)
    {
        var user = await _userManager.Users.SingleOrDefaultAsync(user => user.Id == id);
        return user ?? throw new EntityNotFoundException(GetUserNotFoundErrorMessage(id));
    }

    public async Task UpdateAsync(User user)
    {
        await _userManager.UpdateAsync(user);
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await GetByIdAsync(id);
        await _userManager.DeleteAsync(user);
    }

    private static string GetUserNotFoundErrorMessage(Guid id) =>
        $"{nameof(User)} with id {id} not found.";
}
