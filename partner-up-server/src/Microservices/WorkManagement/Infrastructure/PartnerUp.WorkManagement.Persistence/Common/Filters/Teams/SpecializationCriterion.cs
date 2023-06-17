using System.Linq.Expressions;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Persistence.Common.Filters.Teams;

public class SpecializationCriterion : IFilterCriterion<Team>
{
    private readonly TeamsParameters _parameters;

    public SpecializationCriterion(TeamsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Specialization);

    public Expression<Func<Team, bool>> Expression =>
        team => team.Specialization == _parameters.Specialization;
}
