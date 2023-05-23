﻿using AutoMapper;
using MediatR;
using PartnerUp.WorkManagement.Application.Interfaces.Data;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.Application.Features.Teams.Commands.CreateTeam;

public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateTeamCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        var team = _mapper.Map<CreateTeamCommand, Team>(request);
        var leader = new UserProfile { Id = request.LeaderId };
        team.Members = new List<UserProfile> { leader };
        await _unitOfWork.TeamsRepository.InsertAsync(team);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
