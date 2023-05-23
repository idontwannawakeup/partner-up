using PartnerUp.Shared.Interfaces;
using PartnerUp.Shared.Pagination;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Application.Interfaces.Data.Repositories;

public interface IProjectsRepository : IRepository<Project>
{
    Task<PagedList<Project>> GetAsync(ProjectsParameters parameters);
    Task<IEnumerable<Project>> GetAsync(IEnumerable<Guid> ids);
}
