using AutoMapper;
using Grpc.Net.Client;
using MediatR;
using PartnerUp.Content.Application.Common.Models.Responses;
using PartnerUp.Content.Application.Common.Settings;
using PartnerUp.Content.Application.Interfaces.Data;
using PartnerUp.Content.Application.Grpc.Definitions;
using PartnerUp.Content.Domain.Enums;

namespace PartnerUp.Content.Application.Features.Recent.Queries.GetRecentTeams;

public class GetRecentTeamsQueryHandler
    : IRequestHandler<GetRecentTeamsQuery, IEnumerable<TeamResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ServicesSettings _settings;

    public GetRecentTeamsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ServicesSettings settings)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _settings = settings;
    }

    public async Task<IEnumerable<TeamResponse>> Handle(
        GetRecentTeamsQuery request,
        CancellationToken cancellationToken)
    {
        var recent = await _unitOfWork.RecentRequestRepository.GetAsync(
            request.UserId,
            RecentRequestEntityType.Team);

        var grpcRequest = new GetRecentTeamsRequest
        {
            Ids = { recent.Select(r => r.RequestedEntityId.ToString()) }
        };

        using var channel = GrpcChannel.ForAddress(_settings.WorkManagementGrpcUrl);
        var client = new RecentRequestsService.RecentRequestsServiceClient(channel);
        var response = await client.GetRecentTeamsAsync(
            grpcRequest,
            cancellationToken: cancellationToken);

        return _mapper.Map<IEnumerable<TeamResponse>>(response.Teams);
    }
}
