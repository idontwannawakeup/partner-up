using PartnerUp.Shared.Filters;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;
using PartnerUp.WorkManagement.Persistence.Common.Filters.Projects;

namespace PartnerUp.WorkManagement.Persistence.Common.Factories.FilterFactories;

public class ProjectFilterFactory : IFilterFactory<Project>
{
    public IFilter<Project> Get<TParams>(TParams parameters) where TParams : IFilterParameters<Project>
    {
        return new Filter<Project>(new IFilterCriterion<Project>[]
        {
            new TeamIdCriterion(parameters as ProjectsParameters ?? new ProjectsParameters()),
            new TeamMemberIdCriterion(parameters as ProjectsParameters ?? new ProjectsParameters()),
            new TitleCriterion(parameters as ProjectsParameters ?? new ProjectsParameters()),
        });
    }
}
