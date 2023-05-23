using System.Linq.Expressions;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Persistence.Common.Filters.Tickets;

public class ProjectIdCriterion : IFilterCriterion<Ticket>
{
    private readonly TicketsParameters _parameters;

    public ProjectIdCriterion(TicketsParameters parameters) => _parameters = parameters;

    public bool Condition => _parameters.ProjectId is not null;

    public Expression<Func<Ticket, bool>> Expression =>
        ticket => ticket.ProjectId == _parameters.ProjectId;
}
