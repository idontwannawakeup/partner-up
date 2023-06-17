using PartnerUp.Identity.Persistence.People.Common.Filters.Users;
using PartnerUp.Identity.Persistence.People.Common.Parameters;
using PartnerUp.Identity.Persistence.People.Data.Entities;
using PartnerUp.Shared.Filters;
using PartnerUp.Shared.Interfaces.Filters;

namespace PartnerUp.Identity.Persistence.People.Common.Factories.FilterFactories;

public class UserFilterFactory : IFilterFactory<User>
{
    public IFilter<User> Get<TParams>(TParams parameters) where TParams : IFilterParameters<User>
    {
        return new Filter<User>(new IFilterCriterion<User>[]
        {
            new LastNameCriterion(parameters as UsersParameters ?? new UsersParameters()),
        });
    }
}
