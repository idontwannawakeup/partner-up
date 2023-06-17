using System.Linq.Expressions;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Persistence.Common.Filters.Projects;

public class TeamMemberIdCriterion : IFilterCriterion<Project>
{
    private readonly ProjectsParameters _parameters;

    public TeamMemberIdCriterion(ProjectsParameters parameters) => _parameters = parameters;

    public bool Condition => _parameters.TeamMemberId is not null;

    public Expression<Func<Project, bool>> Expression => project =>
        project.Team.Members.Any(user => user.Id == _parameters.TeamMemberId);
}
