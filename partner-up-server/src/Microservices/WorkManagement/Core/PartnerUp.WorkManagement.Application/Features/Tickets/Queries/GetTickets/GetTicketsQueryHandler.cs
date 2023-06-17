using AutoMapper;
using MediatR;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;
using PartnerUp.WorkManagement.Application.Interfaces.Data;
using PartnerUp.Shared.Pagination;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.Application.Features.Tickets.Queries.GetTickets;

public class GetTicketsQueryHandler : IRequestHandler<GetTicketsQuery, PagedList<TicketResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTicketsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedList<TicketResponse>> Handle(
        GetTicketsQuery request,
        CancellationToken cancellationToken)
    {
        var tickets = await _unitOfWork.TicketsRepository.GetAsync(request.Parameters);
        return tickets.Map(_mapper.Map<Ticket, TicketResponse>);
    }
}
