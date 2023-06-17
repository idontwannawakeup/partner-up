using AutoMapper;
using MediatR;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;
using PartnerUp.WorkManagement.Application.Interfaces.Data;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.Application.Features.Teams.Queries.GetUserTeams;

public class GetUserTeamsQueryHandler : IRequestHandler<GetUserTeamsQuery, IEnumerable<TeamResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUserTeamsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TeamResponse>> Handle(
        GetUserTeamsQuery request,
        CancellationToken cancellationToken)
    {
        var user = new UserProfile { Id = request.UserId };
        var teams = await _unitOfWork.TeamsRepository.GetUserTeams(user);
        return teams.Select(_mapper.Map<Team, TeamResponse>);
    }
}
