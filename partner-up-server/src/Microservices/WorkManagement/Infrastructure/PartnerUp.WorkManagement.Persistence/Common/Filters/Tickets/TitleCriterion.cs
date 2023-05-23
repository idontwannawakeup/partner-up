using System.Linq.Expressions;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Persistence.Common.Filters.Tickets;

public class TitleCriterion : IFilterCriterion<Ticket>
{
    private readonly TicketsParameters _parameters;

    public TitleCriterion(TicketsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Title);

    public Expression<Func<Ticket, bool>> Expression =>
        ticket => ticket.Title.Contains(_parameters.Title!);
}
