﻿using Microsoft.EntityFrameworkCore;
using PartnerUp.Shared.Exceptions;
using PartnerUp.Shared.Extensions;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.Shared.Pagination;
using PartnerUp.WorkManagement.Application.Interfaces.Data.Repositories;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Persistence.Data.Repositories;

public class TeamsRepository : GenericRepository<Team>, ITeamsRepository
{
    private readonly IFilterFactory<Team> _filter;

    public TeamsRepository(WorkManagementDbContext databaseContext, IFilterFactory<Team> filter) :
        base(databaseContext) => _filter = filter;

    public override async Task<Team> GetCompleteEntityAsync(Guid id)
    {
        var team = await Table.Include(team => team.Leader)
                              .Include(team => team.Projects)
                              .Include(team => team.Members)
                              .SingleOrDefaultAsync(team => team.Id == id);

        return team ?? throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
    }

    public async Task<PagedList<Team>> GetAsync(TeamsParameters parameters)
    {
        IQueryable<Team> source = Table.Include(team => team.Leader)
                                       .FilterWith(_filter.Get(parameters));

        return await PagedList<Team>.ToPagedListAsync(
            source,
            parameters.PageNumber,
            parameters.PageSize);
    }

    public async Task<IEnumerable<Team>> GetAsync(IEnumerable<Guid> ids)
    {
        return await Table.Where(team => ids.Contains(team.Id)).ToListAsync();
    }

    public async Task<IEnumerable<Team>> GetUserTeams(UserProfile user) =>
        await Table.Where(team => team.Members.Contains(user)).ToListAsync();

    public async Task<IEnumerable<UserProfile>> GetMembersAsync(Guid id)
    {
        var team = await Table.Include(team => team.Members)
                              .SingleOrDefaultAsync(team => team.Id == id);

        if (team is null)
        {
            throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        return team.Members;
    }

    public async Task AddMemberAsync(Guid id, UserProfile member)
    {
        var team = await Table.Include(team => team.Members)
                              .SingleOrDefaultAsync(team => team.Id == id);

        if (team is null)
        {
            throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        team.Members.Add(member);
    }

    public async Task DeleteMemberAsync(Guid id, UserProfile member)
    {
        var team = await Table.Include(team => team.Members)
                              .SingleOrDefaultAsync(team => team.Id == id);

        if (team is null)
        {
            throw new EntityNotFoundException(GetEntityNotFoundErrorMessage(id));
        }

        team.Members.Remove(member);
    }
}
