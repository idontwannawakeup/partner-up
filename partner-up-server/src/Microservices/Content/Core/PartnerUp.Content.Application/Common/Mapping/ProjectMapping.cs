using AutoMapper;
using PartnerUp.Content.Application.Common.Models.Responses;
using PartnerUp.Content.Application.Grpc.Definitions;

namespace PartnerUp.Content.Application.Common.Mapping;

public class ProjectMapping : Profile
{
    public ProjectMapping()
    {
        CreateMap<GetRecentProjectResponse, ProjectResponse>()
            .ForMember(
                response => response.Id,
                options => options.MapFrom(p => Guid.Parse(p.Id)))
            .ForMember(
                response => response.TeamId,
                options => options.MapFrom(p => Guid.Parse(p.TeamId)));
    }
}
