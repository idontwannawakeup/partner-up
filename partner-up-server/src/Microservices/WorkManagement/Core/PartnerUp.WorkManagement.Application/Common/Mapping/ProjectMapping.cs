using AutoMapper;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;
using PartnerUp.WorkManagement.Application.Features.Projects.Commands.CreateProject;
using PartnerUp.WorkManagement.Application.Features.Projects.Commands.UpdateProject;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.Application.Common.Mapping;

public class ProjectMapping : Profile
{
    public ProjectMapping()
    {
        CreateMap<CreateProjectCommand, Project>();
        CreateMap<UpdateProjectCommand, Project>();
        CreateMap<Project, ProjectResponse>();
    }
}
