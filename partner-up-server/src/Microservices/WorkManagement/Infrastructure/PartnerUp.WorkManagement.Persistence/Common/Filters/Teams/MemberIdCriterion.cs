using System.Linq.Expressions;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Persistence.Common.Filters.Teams;

public class MemberIdCriterion : IFilterCriterion<Team>
{
    private readonly TeamsParameters _parameters;

    public MemberIdCriterion(TeamsParameters parameters) => _parameters = parameters;

    public bool Condition => _parameters.UserId is not null;

    public Expression<Func<Team, bool>> Expression =>
        team => team.Members.Any(user => user.Id == _parameters.UserId);
}
