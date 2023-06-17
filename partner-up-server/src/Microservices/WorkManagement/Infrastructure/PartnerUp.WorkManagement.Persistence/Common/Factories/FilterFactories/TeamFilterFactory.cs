using PartnerUp.Shared.Filters;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;
using PartnerUp.WorkManagement.Persistence.Common.Filters.Teams;

namespace PartnerUp.WorkManagement.Persistence.Common.Factories.FilterFactories;

public class TeamFilterFactory : IFilterFactory<Team>
{
    public IFilter<Team> Get<TParams>(TParams parameters) where TParams : IFilterParameters<Team>
    {
        return new Filter<Team>(new IFilterCriterion<Team>[]
        {
            new MemberIdCriterion(parameters as TeamsParameters ?? new TeamsParameters()),
            new NameCriterion(parameters as TeamsParameters ?? new TeamsParameters()),
            new SpecializationCriterion(parameters as TeamsParameters ?? new TeamsParameters()),
        });
    }
}
