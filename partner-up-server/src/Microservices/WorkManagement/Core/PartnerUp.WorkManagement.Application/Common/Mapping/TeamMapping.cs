using AutoMapper;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;
using PartnerUp.WorkManagement.Application.Features.Teams.Commands.CreateTeam;
using PartnerUp.WorkManagement.Application.Features.Teams.Commands.UpdateTeam;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.Application.Common.Mapping;

public class TeamMapping : Profile
{
    public TeamMapping()
    {
        CreateMap<CreateTeamCommand, Team>();
        CreateMap<UpdateTeamCommand, Team>();
        CreateMap<Team, TeamResponse>()
            .ForMember(
                response => response.Avatar,
                options => options.MapFrom(
                    team => !string.IsNullOrWhiteSpace(team.Avatar)
                        ? $"CoreService/Public/Photos/{team.Avatar}"
                        : null));
    }
}
