using PartnerUp.Shared.Interfaces.Filters;

namespace PartnerUp.Shared.Filters;

public class Filter<T> : IFilter<T>
{
    private readonly IReadOnlyCollection<IFilterCriterion<T>> _criteria;

    public Filter(IReadOnlyCollection<IFilterCriterion<T>> criteria) => _criteria = criteria;

    public IQueryable<T> ApplyFilters(IQueryable<T> items) =>
        _criteria.Where(filterCriterion => filterCriterion.Condition)
                 .Aggregate(items, ApplyCriterion);

    private static IQueryable<T> ApplyCriterion(
        IQueryable<T> current,
        IFilterCriterion<T> filterCriterion) =>
        current.Where(filterCriterion.Expression);
}
