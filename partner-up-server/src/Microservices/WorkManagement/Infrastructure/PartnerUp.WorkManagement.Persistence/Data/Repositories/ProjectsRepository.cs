﻿using Microsoft.EntityFrameworkCore;
using PartnerUp.Shared.Exceptions;
using PartnerUp.Shared.Extensions;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.Shared.Pagination;
using PartnerUp.WorkManagement.Application.Interfaces.Data.Repositories;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Persistence.Data.Repositories;

public class ProjectsRepository : GenericRepository<Project>, IProjectsRepository
{
    private readonly IFilterFactory<Project> _filter;

    public ProjectsRepository(WorkManagementDbContext databaseContext, IFilterFactory<Project> filter)
        : base(databaseContext) => _filter = filter;

    public override async Task<Project> GetCompleteEntityAsync(Guid id)
    {
        var project = await Table.Include(project => project.Team)
                                 .Include(project => project.Tickets)
                                 .SingleOrDefaultAsync(project => project.Id == id);

        return project ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
    }

    public async Task<PagedList<Project>> GetAsync(ProjectsParameters parameters)
    {
        IQueryable<Project> source = Table.Include(project => project.Team)
                                          .FilterWith(_filter.Get(parameters));

        return await PagedList<Project>.ToPagedListAsync(
            source,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<IEnumerable<Project>> GetAsync(IEnumerable<Guid> ids)
    {
        return await Table.Where(project => ids.Contains(project.Id)).ToListAsync();
    }

    public async Task<Team> GetRelatedTeamAsync(Guid id)
    {
        var project = await Table.Include(project => project.Team)
                                 .SingleOrDefaultAsync(project => project.Id == id);

        return project?.Team
               ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
    }
}
