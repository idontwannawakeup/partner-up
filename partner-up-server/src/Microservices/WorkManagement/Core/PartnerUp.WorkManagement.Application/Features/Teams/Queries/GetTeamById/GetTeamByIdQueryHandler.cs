using AutoMapper;
using MediatR;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;
using PartnerUp.WorkManagement.Application.Interfaces.Data;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.Application.Features.Teams.Queries.GetTeamById;

public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, TeamResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTeamByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TeamResponse> Handle(
        GetTeamByIdQuery request,
        CancellationToken cancellationToken)
    {
        var team = await _unitOfWork.TeamsRepository.GetByIdAsync(request.Id);
        return _mapper.Map<Team, TeamResponse>(team);
    }
}
