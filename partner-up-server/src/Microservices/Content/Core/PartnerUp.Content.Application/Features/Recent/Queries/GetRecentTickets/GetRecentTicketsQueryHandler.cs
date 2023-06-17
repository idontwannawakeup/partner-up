using AutoMapper;
using Grpc.Net.Client;
using MediatR;
using PartnerUp.Content.Application.Common.Models.Responses;
using PartnerUp.Content.Application.Common.Settings;
using PartnerUp.Content.Application.Interfaces.Data;
using PartnerUp.Content.Application.Grpc.Definitions;
using PartnerUp.Content.Domain.Enums;

namespace PartnerUp.Content.Application.Features.Recent.Queries.GetRecentTickets;

public class GetRecentTicketsQueryHandler
    : IRequestHandler<GetRecentTicketsQuery, IEnumerable<TicketResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ServicesSettings _settings;

    public GetRecentTicketsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ServicesSettings settings)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _settings = settings;
    }

    public async Task<IEnumerable<TicketResponse>> Handle(
        GetRecentTicketsQuery request,
        CancellationToken cancellationToken)
    {
        var recent = await _unitOfWork.RecentRequestRepository.GetAsync(
            request.UserId,
            RecentRequestEntityType.Ticket);

        var grpcRequest = new GetRecentTicketsRequest
        {
            Ids = { recent.Select(r => r.RequestedEntityId.ToString()) }
        };

        using var channel = GrpcChannel.ForAddress(_settings.WorkManagementGrpcUrl);
        var client = new RecentRequestsService.RecentRequestsServiceClient(channel);
        var response = await client.GetRecentTicketsAsync(
            grpcRequest,
            cancellationToken: cancellationToken);

        return _mapper.Map<IEnumerable<TicketResponse>>(response.Tickets);
    }
}
