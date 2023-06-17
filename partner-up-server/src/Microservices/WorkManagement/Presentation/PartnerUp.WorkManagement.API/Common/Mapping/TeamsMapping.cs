using AutoMapper;
using PartnerUp.WorkManagement.API.Grpc.Definitions;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.API.Common.Mapping;

public class TeamsMapping : Profile
{
    public TeamsMapping()
    {
        CreateMap<Team, GetRecentTeamResponse>()
            .ForMember(
                response => response.Id,
                options => options.MapFrom(t => t.Id.ToString()))
            .ForMember(
                response => response.LeaderId,
                options => options.MapFrom(t => t.LeaderId.ToString()))
            .ForMember(
                response => response.Specialization,
                options => options.MapFrom(t => t.Specialization ?? string.Empty))
            .ForMember(
                response => response.About,
                options => options.MapFrom(t => t.About ?? string.Empty))
            .ForMember(
                response => response.Avatar,
                options => options.MapFrom(t => t.Avatar ?? string.Empty));
    }
}
