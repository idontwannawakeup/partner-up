﻿using AutoMapper;
using MediatR;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;
using PartnerUp.WorkManagement.Application.Interfaces.Data;

namespace PartnerUp.WorkManagement.Application.Features.Teams.Queries.GetTeamMembers;

public class GetTeamMembersQueryHandler : IRequestHandler<GetTeamMembersQuery, IEnumerable<UserResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTeamMembersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserResponse>> Handle(
        GetTeamMembersQuery request,
        CancellationToken cancellationToken)
    {
        var members = await _unitOfWork.TeamsRepository.GetMembersAsync(request.TeamId);
        return _mapper.Map<IEnumerable<UserResponse>>(members);
    }
}
