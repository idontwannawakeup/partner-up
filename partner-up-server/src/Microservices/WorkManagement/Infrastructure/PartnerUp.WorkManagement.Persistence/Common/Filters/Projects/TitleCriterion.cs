using System.Linq.Expressions;
using PartnerUp.Shared.Interfaces.Filters;
using PartnerUp.WorkManagement.Domain.Entities;
using PartnerUp.WorkManagement.Domain.Parameters;

namespace PartnerUp.WorkManagement.Persistence.Common.Filters.Projects;

public class TitleCriterion : IFilterCriterion<Project>
{
    private readonly ProjectsParameters _parameters;

    public TitleCriterion(ProjectsParameters parameters) => _parameters = parameters;

    public bool Condition => !string.IsNullOrWhiteSpace(_parameters.Title);

    public Expression<Func<Project, bool>> Expression =>
        project => project.Title.Contains(_parameters.Title!);
}
