using PartnerUp.Shared.Filters;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;
using PartnerUp.WorkManagement.Persistence.Common.Filters.Tickets;

namespace PartnerUp.WorkManagement.Persistence.Common.Factories.FilterFactories;

public class TicketFilterFactory : IFilterFactory<Ticket>
{
    public IFilter<Ticket> Get<TParams>(TParams parameters) where TParams : IFilterParameters<Ticket>
    {
        return new Filter<Ticket>(new IFilterCriterion<Ticket>[]
        {
            new ExecutorIdCriterion(parameters as TicketsParameters ?? new TicketsParameters()),
            new ProjectIdCriterion(parameters as TicketsParameters ?? new TicketsParameters()),
            new StatusCriterion(parameters as TicketsParameters ?? new TicketsParameters()),
            new TitleCriterion(parameters as TicketsParameters ?? new TicketsParameters()),
        });
    }
}
