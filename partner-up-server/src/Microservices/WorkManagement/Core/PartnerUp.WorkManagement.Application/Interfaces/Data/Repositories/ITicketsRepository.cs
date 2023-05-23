using PartnerUp.Shared.Interfaces;
using PartnerUp.Shared.Pagination;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Application.Interfaces.Data.Repositories;

public interface ITicketsRepository : IRepository<Ticket>
{
    Task<PagedList<Ticket>> GetAsync(TicketsParameters parameters);
    Task<IEnumerable<Ticket>> GetAsync(IEnumerable<Guid> ids);
}
