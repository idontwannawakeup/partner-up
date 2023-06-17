using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.Shared.Parameters;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.Domain.Parameters;

public class TicketsParameters : QueryStringParameters, IFilterParameters<Ticket>
{
    public Guid? ProjectId { get; set; }
    public Guid? ExecutorId { get; set; }
    public string? Title { get; set; }
    public string? Status { get; set; }
}
