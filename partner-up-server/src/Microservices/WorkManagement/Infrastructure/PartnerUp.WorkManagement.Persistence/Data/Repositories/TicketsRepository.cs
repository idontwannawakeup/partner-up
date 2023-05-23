using Microsoft.EntityFrameworkCore;
using PartnerUp.Shared.Exceptions;
using PartnerUp.Shared.Extensions;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.Shared.Pagination;
using PartnerUp.WorkManagement.Application.Interfaces.Data.Repositories;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Persistence.Data.Repositories;

public class TicketsRepository : GenericRepository<Ticket>, ITicketsRepository
{
    private readonly IFilterFactory<Ticket> _filter;

    public TicketsRepository(WorkManagementDbContext databaseContext, IFilterFactory<Ticket> filter)
        : base(databaseContext) => _filter = filter;

    public override async Task<Ticket> GetCompleteEntityAsync(Guid id)
    {
        var ticket = await Table.Include(ticket => ticket.Executor)
                                .Include(ticket => ticket.Project)
                                .ThenInclude(project => project.Team)
                                .SingleOrDefaultAsync(ticket => ticket.Id == id);

        return ticket ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
    }

    public async Task<PagedList<Ticket>> GetAsync(TicketsParameters parameters)
    {
        IQueryable<Ticket> source = Table.Include(ticket => ticket.Executor)
                                         .Include(ticket => ticket.Project)
                                         .ThenInclude(project => project.Team)
                                         .FilterWith(_filter.Get(parameters));

        return await PagedList<Ticket>.ToPagedListAsync(
            source,
            parameters.PageNumber,
            parameters.PageSize);
    }
    
    public async Task<IEnumerable<Ticket>> GetAsync(IEnumerable<Guid> ids)
    {
        return await Table.Where(ticket => ids.Contains(ticket.Id)).ToListAsync();
    }
}
