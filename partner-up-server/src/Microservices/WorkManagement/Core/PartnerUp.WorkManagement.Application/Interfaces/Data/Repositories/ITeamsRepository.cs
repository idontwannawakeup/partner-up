using PartnerUp.Shared.Interfaces;
using PartnerUp.Shared.Pagination;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Application.Interfaces.Data.Repositories;

public interface ITeamsRepository : IRepository<Team>
{
    Task<PagedList<Team>> GetAsync(TeamsParameters parameters);
    Task<IEnumerable<Team>> GetAsync(IEnumerable<Guid> ids);
    Task<IEnumerable<Team>> GetUserTeams(UserProfile user);
    Task<IEnumerable<UserProfile>> GetMembersAsync(Guid id);
    Task AddMemberAsync(Guid id, UserProfile member);
    Task DeleteMemberAsync(Guid id, UserProfile member);
}
