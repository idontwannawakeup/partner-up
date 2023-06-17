using System.Linq.Expressions;

namespace PartnerUp.Shared.Interfaces.Filters;

public interface IFilterCriterion<T>
{
    public bool Condition { get; }
    public Expression<Func<T, bool>> Expression { get; }
}
