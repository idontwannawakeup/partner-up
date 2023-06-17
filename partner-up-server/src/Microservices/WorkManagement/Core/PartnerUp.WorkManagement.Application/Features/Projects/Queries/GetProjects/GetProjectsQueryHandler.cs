using AutoMapper;
using MediatR;
using PartnerUp.WorkManagement.Application.Common.Models.Responses;
using PartnerUp.WorkManagement.Application.Interfaces.Data;
using PartnerUp.Shared.Pagination;
using PartnerUp.WorkManagement.Domain.Entities;

namespace PartnerUp.WorkManagement.Application.Features.Projects.Queries.GetProjects;

public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, PagedList<ProjectResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProjectsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PagedList<ProjectResponse>> Handle(
        GetProjectsQuery request,
        CancellationToken cancellationToken)
    {
        var projects = await _unitOfWork.ProjectsRepository.GetAsync(request.Parameters);
        return projects.Map(_mapper.Map<Project, ProjectResponse>);
    }
}
