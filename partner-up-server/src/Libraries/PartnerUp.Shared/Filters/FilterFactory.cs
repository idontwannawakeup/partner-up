using PartnerUp.Shared.Interfaces.Filters;

namespace PartnerUp.Shared.Filters;

public class FilterFactory<T> : IFilterFactory<T>
{
    private readonly IFilterCriteriaFactory _criteriaFactory;

    public FilterFactory(IFilterCriteriaFactory criteriaFactory) =>
        _criteriaFactory = criteriaFactory;

    public IFilter<T> Get<TParams>(TParams parameters) where TParams : IFilterParameters<T> =>
        new Filter<T>(_criteriaFactory.Get<T, TParams>(parameters));
}
