using AutoMapper;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;
using PartnerUp.WorkManagement.Application.Features.Tickets.Commands.CreateTicket;
using PartnerUp.WorkManagement.Application.Features.Tickets.Commands.UpdateTicket;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.Application.Common.Mapping;

public class TicketMapping : Profile
{
    public TicketMapping()
    {
        CreateMap<CreateTicketCommand, Ticket>();
        CreateMap<UpdateTicketCommand, Ticket>();
        CreateMap<Ticket, TicketResponse>();
    }
}
