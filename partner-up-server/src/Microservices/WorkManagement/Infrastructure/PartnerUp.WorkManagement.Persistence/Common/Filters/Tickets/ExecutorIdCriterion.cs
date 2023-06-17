using System.Linq.Expressions;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Persistence.Common.Filters.Tickets;

public class ExecutorIdCriterion : IFilterCriterion<Ticket>
{
    private readonly TicketsParameters _parameters;

    public ExecutorIdCriterion(TicketsParameters parameters) =>
        _parameters = parameters;

    public bool Condition => _parameters.ExecutorId is not null;

    public Expression<Func<Ticket, bool>> Expression =>
        ticket => ticket.ExecutorId == _parameters.ExecutorId;
}
