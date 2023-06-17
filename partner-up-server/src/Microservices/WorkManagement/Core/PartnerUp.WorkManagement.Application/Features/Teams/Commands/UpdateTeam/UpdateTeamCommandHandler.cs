using AutoMapper;
using MediatR;
using PartnerUp.WorkManagement.Application.Interfaces.Data;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.Application.Features.Teams.Commands.UpdateTeam;

public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateTeamCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
    {
        var team = _mapper.Map<UpdateTeamCommand, Team>(request);
        await _unitOfWork.TeamsRepository.UpdateAsync(team);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
